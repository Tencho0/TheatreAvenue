import { Link } from 'react-router-dom'
import './Footer.scss'

export const Footer = () => {
  return (
    <footer className="footer">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="footer__content">
              <Link to="/" className="footer__logo">
                <img src="img/logo.svg" alt="" />
              </Link>
              <span className="footer__copyright">
                © TheatreAvenue, 2019—2021 <br /> Create by{' '}
                <Link to="https://www.facebook.com/MV.Marvel" target="_blank">
                  M-V Mitova
                </Link>
              </span>
              <nav className="footer__nav">
                <Link to="/contacts">Contacts</Link>
                <Link to="/privacy">Privacy policy</Link>
                <Link to="/faq">FAQ</Link>
              </nav>
              <button className="footer__back" type="button">
                <i className="icon ion-ios-arrow-round-up" />
              </button>
            </div>
          </div>
        </div>
      </div>
    </footer>
  )
}
