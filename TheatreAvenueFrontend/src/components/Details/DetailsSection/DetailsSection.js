import { Link, useParams } from 'react-router-dom'
import { isUserLoggedIn } from '../../common/common'
import { useEffect } from 'react'
import './DetailsSection.scss'

export const DetailsSection = ({ item }) => {
  const { id } = useParams()
  const loggedIn = isUserLoggedIn()

  useEffect(() => {
    if (!loggedIn) {
      window.location.replace('/signin')
    }
  }, [])

  return (
    <div className="DetailsSection">
      <section
        className="section section--details section--bg"
        data-bg="img/section/details.jpg"
      >
        <div className="container">
          <div className="row">
            <div className="col-12">
              <h1 className="section__title section__title--mb">
                {item.Title}
              </h1>
            </div>

            <div className="col-12 col-xl-6">
              <div className="card card--details">
                <div className="row">
                  <div className="col-12 col-sm-5 col-md-5 col-lg-5 col-xl-5">
                    <div className="card__cover DetailsPageImage">
                      <img src={item.ImgUrl} alt="" />
                      <span className="card__rate card__rate--green">
                        {item.Price}$
                      </span>
                    </div>
                    <Link to={`/hall/${id}`} className="card__trailer">
                      Book A Ticket
                    </Link>
                  </div>
                  <div className="col-12 col-sm-7 col-md-7 col-lg-7 col-xl-7">
                    <div className="card__content">
                      <ul className="card__meta">
                        <li>
                          <span>Genre:</span>
                          {item.Genre}
                        </li>
                        <li>
                          <span>Start Time:</span>
                          {item['StartTime']}
                        </li>
                        <li>
                          <span>Price:</span>
                          {item.Price}$
                        </li>
                        <li>
                          <span>Actors:</span>
                          <div className="ActorsDiv">{item.Actors}</div>
                        </li>
                        <li>
                          <span>Location:</span>
                          <div className="LocationDiv">{item.Location}</div>
                        </li>
                        <li>
                          <br />
                          <div className="card__description">
                            {item.Description}
                          </div>
                        </li>
                      </ul>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <br />
      <br />
      <br />
    </div>
  )
}
