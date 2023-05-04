import { Link } from 'react-router-dom'

export const PricingOffert = () => {
  return (
    <div className="row row--grid">
      <div className="col-12 col-md-6 col-lg-4 order-md-2 order-lg-1">
        <div className="price">
          <div className="price__item price__item--first">
            <span>Basic</span> <span>Free</span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> 7 days
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> 720p Resolution
            </span>
          </div>
          <div className="price__item price__item--none">
            <span>
              <i className="icon ion-ios-close" /> Limited Availability
            </span>
          </div>
          <div className="price__item price__item--none">
            <span>
              <i className="icon ion-ios-close" /> Desktop Only
            </span>
          </div>
          <div className="price__item price__item--none">
            <span>
              <i className="icon ion-ios-close" /> Limited Support
            </span>
          </div>
          <Link to="#" className="price__btn">
            Choose Plan
          </Link>
        </div>
      </div>

      <div className="col-12 col-md-12 col-lg-4 order-md-1 order-lg-2">
        <div className="price price--premium">
          <div className="price__item price__item--first">
            <span>Premium</span>{' '}
            <span>
              $34.99 <sub>/ month</sub>
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> 1 Month
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> Full HD
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> Lifetime Availability
            </span>
          </div>
          <div className="price__item price__item--none">
            <span>
              <i className="icon ion-ios-close" /> TV &amp; Desktop
            </span>
          </div>
          <div className="price__item price__item--none">
            <span>
              <i className="icon ion-ios-close" /> 24/7 Support
            </span>
          </div>
          <Link to="#" className="price__btn">
            Choose Plan
          </Link>
        </div>
      </div>

      <div className="col-12 col-md-6 col-lg-4 order-md-3">
        <div className="price">
          <div className="price__item price__item--first">
            <span>Cinematic</span>{' '}
            <span>
              $49.99 <sub>/ month</sub>
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> 2 Months
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> Ultra HD
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> Lifetime Availability
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> Any Device
            </span>
          </div>
          <div className="price__item">
            <span>
              <i className="icon ion-ios-checkmark" /> 24/7 Support
            </span>
          </div>
          <Link to="#" className="price__btn">
            Choose Plan
          </Link>
        </div>
      </div>
    </div>
  )
}
