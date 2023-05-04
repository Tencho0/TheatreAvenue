// Import the Link component from the 'react-router-dom' module
import { Link } from 'react-router-dom'

// Import the styles for this component from the './Card.scss' module
import './Card.scss'

// Define a new React component called Card that takes in an 'item' prop
export const Card = ({ item }) => {
  // Render a div element with the class name 'card__cover'
  // Inside the div, render an image element with the source set to the 'image' property of the 'item' prop
  // Also, render a Link element with a dynamic path set to '/details/${item.id}', and the text 'Book'
  // Finally, render a span element with the class name 'card__rate card__rate--green' and the text '${item.ticketPrice}$'
  // Then, render a div element with the class name 'card__content'
  // Inside the div, render an h3 element with the class name 'card__title'
  // Inside the h3 element, render a Link element with the path set to '/details' and the text set to the 'name' property of the 'item' prop
  return (
    <>
      <div className="card__cover">
        <img src={item.image} alt="" />
        <Link to={`/details/${item.id}`} className="card__play">
          Book
        </Link>
        <span className="card__rate card__rate--green">
          {item.ticketPrice}$
        </span>
      </div>
      <div className="card__content">
        <h3 className="card__title theatre-name">
          <Link to={`/details/${item.id}`}>{item.name}</Link>
        </h3>
      </div>
    </>
  )
}
