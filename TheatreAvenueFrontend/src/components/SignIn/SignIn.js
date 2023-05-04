import React, { useState } from 'react'
import { useEffect } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { isUserLoggedIn, setLoginAndRegisterUserData } from '../common/common'
import CircularIndeterminate from '../common/spinner'
import axios from 'axios'
import './SignIn.scss'

export const SignIn = () => {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [rememberMe, setRememberMe] = useState(true)
  const [errors, setErrors] = useState({})
  const [loginError, setLoginError] = useState('')
  const navigate = useNavigate()
  const [showSpinner, setShowSpinner] = useState(false)
  const loggedIn = isUserLoggedIn()

  useEffect(() => {
    if (loggedIn) {
      window.location.replace('/')
    }
  }, [])

  const sendSignInApiCall = () => {
    setShowSpinner(true)
    axios
      .post(`${process.env.REACT_APP_API_URL}/Auth/login`, {
        email: email,
        password: password,
      })
      .then((response) => {
        setLoginAndRegisterUserData(response.data)
        window.location.replace('/')
      })
      .catch((error) => {
        setShowSpinner(false)
        console.error('error')
        console.error(error)
        if (error.response.status === 500) {
          navigate('/error')
        }
        setLoginError(error.response.data)
      })
  }
  const handleSubmit = (event) => {
    event.preventDefault()

    // Validate form fields
    const errors = {}
    if (!email) {
      errors.email = 'Email is required'
    }
    if (!password) {
      errors.password = 'Password is required'
    }

    // If there are errors, update state and return early
    if (Object.keys(errors).length > 0) {
      setErrors(errors)
      return
    }

    setErrors({})
    // Submit form data
    sendSignInApiCall()
  }

  return (
    <div className="sign section--bg" data-bg="img/section/section.jpg">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="sign__content">
              <form onSubmit={handleSubmit} className="sign__form">
                <Link to="/" className="sign__logo">
                  <img src="img/logo.svg" alt="" />
                </Link>

                <div className="sign__error">{loginError}</div>
                <br />
                <div className="sign__group">
                  <input
                    type="text"
                    className={`sign__input ${
                      errors.email && 'sign__input--error'
                    }`}
                    placeholder="Email"
                    value={email}
                    onChange={(event) => setEmail(event.target.value)}
                  />
                  {errors.email && (
                    <div className="sign__error">{errors.email}*</div>
                  )}
                </div>

                <div className="sign__group">
                  <input
                    type="password"
                    className={`sign__input ${
                      errors.password && 'sign__input--error'
                    }`}
                    placeholder="Password"
                    value={password}
                    onChange={(event) => setPassword(event.target.value)}
                  />
                  {errors.password && (
                    <div className="sign__error">{errors.password}*</div>
                  )}
                </div>

                <div className="sign__group sign__group--checkbox">
                  <input
                    id="remember"
                    name="remember"
                    type="checkbox"
                    checked={rememberMe}
                    onChange={(event) => setRememberMe(event.target.checked)}
                  />
                  <label htmlFor="remember">Remember Me</label>
                </div>

                <button className="sign__btn" type="submit">
                  Sign in
                </button>

                <span className="sign__text">
                  Don't have an account? <Link to="/signup">Sign up!</Link>
                </span>

                <span className="sign__text">
                  <Link to="/forgot">Forgot password?</Link>
                </span>
              </form>
              {showSpinner && CircularIndeterminate()}
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
