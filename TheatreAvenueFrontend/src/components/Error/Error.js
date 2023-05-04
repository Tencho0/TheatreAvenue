import { Link } from 'react-router-dom'

export const ErrorPage = () => {
  return (
    <div className="page-404 section--bg" data-bg="img/section/section.jpg">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="page-404__wrap">
              <div className="page-404__content">
                <h1 className="page-404__title">Error</h1>
                <p className="page-404__text">
                  Something went wrong. Sorry, an error has occurred.
                </p>
                <Link to="/" className="page-404__btn">
                  go back
                </Link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
