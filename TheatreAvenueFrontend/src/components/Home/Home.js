import React, { useEffect, useState } from 'react'
import { NewMoviesSection } from './NewMoviesSection/NewMoviesSection'
import { isUserLoggedIn } from '../common/common'
import { useNavigate } from 'react-router-dom'
import { IconButton } from '@mui/material'
import { SmallCard } from '../SmallCard/SmallCard'
import CircularIndeterminate from '../common/spinner'
import HomeImage from './homeimg.jpg'
import CloseIcon from '@mui/icons-material/Close'
import Box from '@mui/material/Box'
import Modal from '@mui/material/Modal'
import axios from 'axios'
import './Home.scss'

export const Home = () => {
  const theatreEventsFromLocalStorage = JSON.parse(
    localStorage.getItem('AllTheatreEvents')
  )
  const [theatreEvents, setTheatreEvents] = useState(
    theatreEventsFromLocalStorage || []
  )
  const [searchCriteria, setSearchCriteria] = useState('')
  const [showSpinner, setShowSpinner] = useState(false)
  const loggedIn = isUserLoggedIn()
  const navigate = useNavigate()
  const openTheatreEventReccomandationModal = JSON.parse(
    localStorage.getItem('OpenTheatreEventReccomandationModal')
  )
  const [openReccomendationModal, setOpenReccomendationModal] =
    React.useState(false)
  const reccomendedTheatreEvents = JSON.parse(
    localStorage.getItem('ReccomendedTheatreEvents')
  )

  const reccomendedTheatreEventsNames = reccomendedTheatreEvents
    ?.map((item) => item.name)
    .join('|')

  const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    padding: '20px',
    transform: 'translate(-50%, -50%)',
    bgcolor: 'background.paper',
    border: '1px solid #000',
    width: '1000px',
    height: 'auto',
    boxShadow: 24,
    p: 4,
  }

  useEffect(() => {
    if (loggedIn && theatreEvents.length < 1) {
      setShowSpinner(true)
      getTheatreEvents()
    }
  }, [])

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
        setTheatreEvents(response.data)
        localStorage.setItem('AllTheatreEvents', JSON.stringify(response.data))
        setShowSpinner(false)
        if (openTheatreEventReccomandationModal) {
          setOpenReccomendationModal(true)
          localStorage.setItem('OpenTheatreEventReccomandationModal', false)
        }
      })
      .catch((error) => {
        console.error(error)
        navigate('/error')
      })
  }

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
        <h1>Recommended Events</h1>
        <br />
        <div className="row reccomenedEventsModal">
          {reccomendedTheatreEvents?.map((event, i) => {
            return <SmallCard key={i} item={event} />
          })}
        </div>
      </Box>
    </Modal>
  )

  return (
    <div className="App-header">
      <br />
      <h1 className="HomeHeader">Welcome to Theatre Avenue</h1>
      <div>
        <img className="HomeImage" src={HomeImage} alt="My Image" />
      </div>
      <br />

      <div id="homePageWelcomeText">
        <p>
          Welcome to our Broadway theater website, where you can find the best
          selection of tickets to the hottest shows in town! Whether you're a
          seasoned theater-goer or a first-timer, we've got something for
          everyone.
        </p>
        <p>
          Our website features a user-friendly interface that allows you to
          easily browse through our extensive collection of Broadway shows, view
          performance schedules, and purchase tickets with just a few clicks.
          From classic musicals to cutting-edge dramas, we offer a wide range of
          genres and styles to suit every taste.
        </p>
        <p>
          We take pride in providing our customers with exceptional service and
          support throughout the ticket purchasing process. Our knowledgeable
          staff is available to answer any questions you may have and ensure
          that your experience with us is as smooth and enjoyable as possible.
        </p>
        <p>
          So whether you're planning a night out with friends, a romantic date,
          or a family outing, we've got you covered. Don't miss out on the
          excitement and magic of Broadway – book your tickets today and let us
          help you create unforgettable memories!
        </p>
      </div>
      <br />

      {loggedIn && theatreEvents.length > 0 && (
        <>
          <form action="#" className="header__search">
            <input
              className="header__search-input"
              type="text"
              placeholder="Search by title..."
              onChange={(e) => setSearchCriteria(e.target.value)}
            />
            <button className="header__search-button" type="button">
              <i className="icon ion-ios-search" />
            </button>
            <button className="header__search-close" type="button">
              <i className="icon ion-md-close" />
            </button>
          </form>
          <button className="header__search-btn" type="button">
            <i className="icon ion-ios-search" />
          </button>

          <NewMoviesSection
            theatreEvents={theatreEvents.filter((ev) =>
              ev.name
                .toLocaleLowerCase()
                .startsWith(searchCriteria.toLocaleLowerCase())
            )}
          />
          <br />
          <br />
        </>
      )}

      {loggedIn && (
        <>
          <div className="HomePageDresscodeText">
            <strong>Dress Code</strong>
            <p>
              Although there isn't a set dress code for Broadway, it's ideal to
              wear something comfortable, semi-formal, and either semi-casual or
              dressy. Therefore, jeans are OK, but sweatpants or anything that
              leans toward athletics should be avoided. It might become a little
              chilly inside the theater during performances, but both Broadway
              and off-Broadway theaters have air conditioning that runs all year
              long. Therefore, it is advisable to additionally bring a
              lightweight jacket, cardigan, or sweater, particularly if you get
              chilly quickly.
            </p>
            <strong>Explaining Broadway Venue</strong>
            <p>
              A Broadway show's seating arrangement is nearly as crucial as the
              performance itself. If you choose the incorrect seats and have to
              strain your neck to view the stars or are unable to see the stage,
              the unique experience of seeing your favorite tale come life on
              stage may be lessened. Choosing the finest seats with your
              Broadway Tickets will help you get the most out of your Broadway
              experience. The Orchestra, Front Mezzanine, and Rear Mezzanine
              sections are the most common in theaters. However, some theaters
              also provide standing room, box, and balcony sections. In every
              theater, the orchestra is the first sitting area. There is a
              little inclination as the row number rises, but this is the sole
              area that is not raised. The orchestra is the most favored and
              costly seating location in a Broadway theater due to its proximity
              to the stage and breathtaking views. In general, the orchestra row
              has greater legroom than other seats in the theater and provides
              clear stage views, particularly from the front and center rows.
              Most theaters include either one or two mezzanine sections—the
              front and back mezzanine—depending on their size. The first raised
              seating area in the theater is the front mezzanine, which provides
              a superb view of the stage. This section's initial few rows are
              among the most costly and upscale in the whole venue. The front
              mezzanine area often has fewer rows than the back, particularly if
              the theater also contains a rear mezzanine section. In every
              Broadway theater, the balcony is the final row of seats. The
              balcony, which is only available in large theaters, is renowned
              for having the most affordable seats in the house. As you may
              expect, the view from the balcony seats isn't very impressive. Due
              to the way certain theaters are built, the extreme corners of the
              balcony give a side view of the stage. You may choose seats in the
              first few rows if you need last-minute Broadway tickets and have
              no choice but to sit on the balcony.
            </p>

            <strong>Why Purchase Tickets for Theatre Avenue Online?</strong>
            <p>
              No more waiting: Purchase your tickets online instantly to avoid
              standing in line at the box office. You won't again have to be
              concerned about missing the start of the program again. • Purchase
              in advance: By ordering your Broadway tickets days, weeks, or even
              months in advance, you may save time and organize your day well in
              advance. • Great Discounts: It's quite probable that you will find
              appealing discounts while purchasing your Broadway tickets online,
              enabling you to do so at a lower price. • immediate booking
              confirmation: For a fully hassle-free booking experience, Broadway
              Show Tickets provides you with immediate booking confirmation.
            </p>
          </div>
          <br />
          <br />
        </>
      )}

      {showSpinner && CircularIndeterminate()}
      {renderReccomendationModal()}
    </div>
  )
}
