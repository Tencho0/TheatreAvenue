import { Link } from 'react-router-dom'
import { SmallCard } from '../../SmallCard/SmallCard'
import { isUserLoggedIn } from '../../common/common'
import './NewMoviesSection.scss'

export const NewMoviesSection = ({ theatreEvents }) => {
  const loggedIn = isUserLoggedIn()

  return (
    <section className="content">
      <div className="content__head">
        <div className="container">
          <div className="row">
            <div className="col-12">
              {loggedIn && <h2 className="content__title">Theatre Avenue</h2>}
              <ul
                className="nav nav-tabs content__tabs"
                id="content__tabs"
                role="tablist"
              >
                <li className="nav-item">
                  <Link
                    className="nav-link active"
                    data-toggle="tab"
                    to="#tab-1"
                    role="tab"
                    aria-controls="tab-1"
                    aria-selected="true"
                  >
                    Theatre Events
                  </Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <div className="container">
        <div className="tab-content">
          <div
            className="tab-pane fade show active"
            id="tab-1"
            role="tabpanel"
            aria-labelledby="1-tab"
          >
            <div className="row row--grid">
              {theatreEvents.map((event, i) => {
                return <SmallCard key={i} item={event} />
              })}
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}
