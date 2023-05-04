import axios from 'axios'
import React, { useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { isUserLoggedIn } from '../common/common'
import { useEffect } from 'react'
import { IconButton } from '@mui/material'
import CircularIndeterminate from '../common/spinner'
import CloseIcon from '@mui/icons-material/Close'
import Box from '@mui/material/Box'
import Modal from '@mui/material/Modal'
import Barcode from 'react-barcode'
import './Hall.scss'

export const Hall = () => {
  const { id } = useParams()
  const navigate = useNavigate()
  const allTheatreEvents = JSON.parse(localStorage.getItem('AllTheatreEvents'))
  const theatreEvent = allTheatreEvents.find((obj) => obj.id.toString() === id)
  const TOTAL_SEATS = theatreEvent.venue.seats.length // total number of seats in the theater
  const SEATS_PER_ROW = 10 // number of seats per row
  const [seats, setSeats] = useState(theatreEvent.venue.seats)
  const [selectedSeats, setSelectedSeats] = useState([])
  const [showSpinner, setShowSpinner] = useState(false)
  const [bookedTheatreEvent, setBookedTheatreEvent] = useState({})
  const [openModal, setOpenModal] = React.useState(false)
  const [openReccomendationModal, setOpenReccomendationModal] =
    React.useState(false)
  const reccomendedSeatNumbers = JSON.parse(
    localStorage.getItem('ReccomendedSeatNumbers')
  )

  const reccomendedTheatreEvents = JSON.parse(
    localStorage.getItem('ReccomendedTheatreEvents')
  )
  const reccomendedTheatreEventsNames = reccomendedTheatreEvents
    ?.map((item) => item.name)
    .join('|')

  const random10DigitNumber = Math.floor(
    1000000000 + Math.random() * 9000000000
  )
  const handleOpenModal = () => setOpenModal(true)
  const handleCloseModal = () => {
    setOpenModal(false)
    navigate('/')
  }

  const loggedIn = isUserLoggedIn()

  useEffect(() => {
    if (!loggedIn) {
      window.location.replace('/signin')
    } else {
      setOpenReccomendationModal(true)
    }
  }, [])

  const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    padding: '20px',
    transform: 'translate(-50%, -50%)',
    bgcolor: 'background.paper',
    border: '1px solid #000',
    width: '400px',
    boxShadow: 24,
    p: 4,
  }

  const handleSeatClick = (seatIndex) => {
    // toggle seat selection
    const updatedSeats = [...seats]
    if (updatedSeats[seatIndex].booked !== true) {
      // If the seat is not taken already
      if (updatedSeats[seatIndex].booked === null) {
        //if the seat is selected
        updatedSeats[seatIndex].booked = false // Unselect the seat
      } else {
        updatedSeats[seatIndex].booked = null // Select the seat
      }

      setSeats(updatedSeats)

      // update selected seats
      const seatNumber = seatIndex + 1
      const seatLabel = `Seat ${seatNumber}`
      if (selectedSeats.includes(seatLabel)) {
        setSelectedSeats(selectedSeats.filter((seat) => seat !== seatLabel))
      } else {
        setSelectedSeats([...selectedSeats, seatLabel])
      }
    }
  }

  const isSeatTaken = (seatIndex) => {
    const result = seats[seatIndex].booked
    return result
  }

  const renderSeats = () => {
    const seatRows = []
    for (let i = 0; i < TOTAL_SEATS; i += SEATS_PER_ROW) {
      const seatRow = []
      for (let j = 0; j < SEATS_PER_ROW; j++) {
        const seatIndex = i + j
        const seatLabel = `Seat ${seatIndex + 1}`
        const isTaken = isSeatTaken(seatIndex)
        let seatClass = isTaken ? 'seat-taken' : 'seat-free'
        let seatStatus = isTaken ? 'Taken' : 'Free'
        if (isTaken === null) {
          seatClass = 'seat-selected'
          seatStatus = 'Select'
        }

        seatRow.push(
          <div
            key={seatIndex}
            className={`seat ${seatClass}`}
            onClick={() => handleSeatClick(seatIndex)}
          >
            <span className="seat-label">{seatLabel}</span>
            <span className="seat-status">{seatStatus}</span>
          </div>
        )
      }
      seatRows.push(
        <div key={i} className="seat-row">
          {seatRow}
        </div>
      )
    }
    return seatRows
  }

  const getTheatreEvents = () => {
    axios
      .get(
        `${
          process.env.REACT_APP_API_URL
        }/TheatreAvenue/all?email=${localStorage.getItem(
          'UserEmail'
        )}&reccomendedTheatreNames=${reccomendedTheatreEventsNames}`,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('AuthToken')}`,
          },
        }
      )
      .then((response) => {
        localStorage.setItem('AllTheatreEvents', JSON.stringify(response.data))
        handleOpenModal()
        setShowSpinner(false)
      })
      .catch((error) => {
        console.error(error)
        navigate('/error')
      })
  }

  const handlePurchase = () => {
    setShowSpinner(true)
    axios
      .post(
        `${process.env.REACT_APP_API_URL}/TheatreAvenue/BookEvent`,
        {
          selectedSeats: selectedSeats,
          theatreEventId: Number(id),
          userEmail: localStorage.getItem('UserEmail'),
        },
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('AuthToken')}`,
          },
        }
      )
      .then((response) => {
        const bookedTheatreEvent = response.data.bookedTheatreEvent
        const reccomendedSeats = response.data.reccomendedSeats
        localStorage.setItem(
          'ReccomendedSeatNumbers',
          JSON.stringify(reccomendedSeats)
        )

        setBookedTheatreEvent(bookedTheatreEvent)
        getTheatreEvents()
      })
      .catch((error) => {
        console.error(error)
        navigate('/error')
      })
  }

  const renderModal = () => (
    <Modal
      keepMounted
      open={openModal}
      onClose={handleCloseModal}
      aria-labelledby="keep-mounted-modal-title"
      aria-describedby="keep-mounted-modal-description"
      className="confirmationModal"
    >
      <Box sx={style}>
        <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
          <IconButton onClick={handleCloseModal}>
            <CloseIcon />
          </IconButton>
        </Box>

        <h1>Congratulations !!!</h1>
        <h3>Here is your Ticket</h3>
        <h3>TAKE A SCREENSHOT</h3>
        <div className="barcode">
          <Barcode value={random10DigitNumber} width={2} height={100} />
        </div>
        <br />
        <div>
          <b>Theatre Event Name:</b> <div>{bookedTheatreEvent?.name}</div>
          <br />
          <b>Description:</b> <div>{bookedTheatreEvent?.description}</div>
          <br />
          <b>Start Time:</b> <div>{bookedTheatreEvent?.startTime}</div>
          <br />
          <b>Booked seats:</b> <div>{selectedSeats.join(', ')}</div>
          <br />
          <b>Venue Name:</b> <div>{bookedTheatreEvent?.venue?.name}</div>
          <br />
          <b>Location:</b>
          <div>{bookedTheatreEvent?.venue?.location?.country}</div>
          <div>{bookedTheatreEvent?.venue?.location?.city}</div>
          <div>{bookedTheatreEvent?.venue?.location?.address}</div>
          <br />
          <b>Price:</b>
          <div>{bookedTheatreEvent?.ticketPrice}</div>
        </div>
      </Box>
    </Modal>
  )

  const renderReccomendationModal = () => (
    <Modal
      keepMounted
      open={openReccomendationModal}
      onClose={() => setOpenReccomendationModal(false)}
      aria-labelledby="keep-mounted-modal-title"
      aria-describedby="keep-mounted-modal-description"
      className="confirmationModal"
    >
      <Box sx={style}>
        <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
          <IconButton onClick={() => setOpenReccomendationModal(false)}>
            <CloseIcon />
          </IconButton>
        </Box>
        <h1>Reccomended Seats</h1>
        <h3>{reccomendedSeatNumbers.join(', ')}</h3>
      </Box>
    </Modal>
  )

  return (
    <div className="theatre">
      <h1>Choose Your Seat</h1>
      <h3>Venue - {theatreEvent.venue.name}</h3>
      <div className="seating-area">{renderSeats()}</div>
      <div className="selected-seats">
        <span>Selected Seats:</span>
        <span>{selectedSeats.join(', ')}</span>
      </div>
      <button onClick={handlePurchase} disabled={!selectedSeats.length}>
        Book Seat
      </button>
      <div>{renderModal()}</div>
      {showSpinner && CircularIndeterminate()}
      {renderReccomendationModal()}
    </div>
  )
}
