import { DetailsSection } from './DetailsSection/DetailsSection'
import { useParams } from 'react-router-dom'
import './Details.scss'

export const Details = () => {
  const { id } = useParams()

  const allTheatreEvents = JSON.parse(localStorage.getItem('AllTheatreEvents'))

  const theatreEvent = allTheatreEvents.find((obj) => obj.id.toString() === id)

  const validTheatreEvent =
    theatreEvent !== undefined && theatreEvent?.length !== 0

  if (validTheatreEvent) {
    let defaultItem = {
      ImgUrl: theatreEvent.image,
      Price: theatreEvent.ticketPrice, //Rate
      Title: theatreEvent.name,
      Actors: theatreEvent.actors, // Cast
      Location: `${theatreEvent.venue.location.country}, ${theatreEvent.venue.location.city}, ${theatreEvent.venue.location.address}`,
      Description: theatreEvent.description,
      Genre: theatreEvent.genre, // Genres
      StartTime: theatreEvent.startTime,
    }

    return <DetailsSection item={defaultItem} />
  }

  return <></>
}
