import { useState } from 'react'
import { Link } from 'react-router-dom'
import { isUserLoggedIn, logout } from '../common/common.js'
import './Header.scss'

export const Header = () => {
  const loggedIn = isUserLoggedIn()

  const logOutUser = () => {
    logout()
  }

  return (
    <header className="header">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="header__content">
              <Link to="/" className="header__logo">
                <img src="img/logo.svg" alt="" />
              </Link>

              <ul className="header__nav">
                <li className="header__nav-item">
                  <Link
                    className="header__nav-link"
                    to="/"
                    role="button"
                    id="menuLinkHome"
                  >
                    Theatres
                  </Link>
                </li>
              </ul>

              {loggedIn && (
                <ul className="header__nav">
                  <li className="header__nav-item">
                    <Link
                      className="header__nav-link"
                      to="/profile"
                      role="button"
                      id="menuLinkProfile"
                    >
                      Profile
                    </Link>
                  </li>
                </ul>
              )}

              <div className="header__auth header__search">
                <div action="#" className="header__search"></div>
                <button className="header__search-btn" type="button">
                  <i className="icon ion-ios-search" />
                </button>
                {loggedIn ? (
                  <Link to="#" onClick={logOutUser} className="header__sign-in">
                    <i className="icon ion-ios-log-in" />
                    <span>log out</span>
                  </Link>
                ) : (
                  <Link to="/signin" className="header__sign-in">
                    <i className="icon ion-ios-log-in" />
                    <span>sign in</span>
                  </Link>
                )}
              </div>

              <button className="header__btn" type="button">
                <span />
                <span />
                <span />
              </button>
            </div>
          </div>
        </div>
      </div>
    </header>
  )
}
