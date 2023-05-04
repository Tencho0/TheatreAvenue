import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { isUserLoggedIn, setLoginAndRegisterUserData } from '../common/common'
import { useEffect } from 'react'
import CircularIndeterminate from '../common/spinner'
import axios from 'axios'
import './Signup.scss'

export const SignUp = () => {
  const [name, setName] = useState('')
  const [sureName, setSureName] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [remember, setRemember] = useState(true)
  const [genrePreferences, setGenrePreferences] = useState('')
  const [nameError, setNameError] = useState('')
  const [sureNameError, setSureNameError] = useState('')
  const [emailError, setEmailError] = useState('')
  const [passwordError, setPasswordError] = useState('')
  const [rememberError, setRememberError] = useState('')
  const [signUpError, setSignUpError] = useState('')
  const [genrePreferencesError, setGenrePreferencesError] = useState('')
  const [showSpinner, setShowSpinner] = useState(false)
  const loggedIn = isUserLoggedIn()

  useEffect(() => {
    if (loggedIn) {
      window.location.replace('/')
    }
  }, [])

  const sendSignUpApiCall = () => {
    setShowSpinner(true)
    axios
      .post(`${process.env.REACT_APP_API_URL}/Auth/register`, {
        name: name,
        sureName: sureName,
        email: email,
        password: password,
        genrePreferences: genrePreferences,
        isAdmin: false,
      })
      .then((response) => {
        setLoginAndRegisterUserData(response.data)
        window.location.replace('/')
      })
      .catch((error) => {
        setShowSpinner(false)
        console.error(error)
        if (error.response.status === 500) {
          navigate('/error')
        }
        setSignUpError(error.response.data)
      })
  }

  const handleSubmit = (event) => {
    event.preventDefault()

    // Validation rules
    const namePattern = /^[a-zA-Z\s]*$/
    const emailPattern = /^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/
    const passwordPattern =
      /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/
    const genrePreferencesPattern = /^[a-zA-Z0-9\s]*$/

    // Name validation
    if (!name && name === ' ') {
      setNameError('Name is required')
      return
    } else if (!namePattern.test(name)) {
      setNameError('Name can only contain letters and spaces')
      return
    } else {
      setNameError('')
    }

    // SureName validation
    if (!sureName && sureName === ' ') {
      setSureNameError('SureName is required')
      return
    } else if (!namePattern.test(sureName)) {
      setSureNameError('SureName can only contain letters and spaces')
      return
    } else {
      setSureNameError('')
    }

    // Email validation
    if (!email) {
      setEmailError('Email is required')
      return
    } else if (!emailPattern.test(email)) {
      setEmailError('Email is invalid')
      return
    } else {
      setEmailError('')
    }

    // Password validation
    if (!password) {
      setPasswordError('Password is required')
      return
    } else if (!passwordPattern.test(password)) {
      setPasswordError(
        'Password must be at least 8 characters and contain at least one uppercase letter, one lowercase letter, and one number'
      )
      return
    } else {
      setPasswordError('')
    }

    // Genre Preferences validation
    if (!genrePreferences || genrePreferences.trim() === '') {
      setGenrePreferencesError('Genre Preferences are required')
      return
    } else if (!genrePreferencesPattern.test(genrePreferences)) {
      setGenrePreferencesError(
        'Genre Preferences can only contain letters, numbers, and spaces'
      )
      return
    } else {
      setGenrePreferencesError('')
    }

    // Remember checkbox validation
    if (!remember) {
      setRememberError('You must agree to the Privacy Policy')
      return
    } else {
      setRememberError('')
    }

    sendSignUpApiCall()
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
                <div className="sign__error">{signUpError}</div>
                <br />
                <div className="sign__group">
                  <input
                    type="text"
                    className="sign__input"
                    placeholder="Name"
                    value={name}
                    onChange={(event) => setName(event.target.value)}
                  />
                  <div className="sign__error">{nameError}</div>
                </div>

                <div className="sign__group">
                  <input
                    type="text"
                    className="sign__input"
                    placeholder="Surname"
                    value={sureName}
                    onChange={(event) => setSureName(event.target.value)}
                  />
                  <div className="sign__error">{sureNameError}</div>
                </div>

                <div className="sign__group">
                  <input
                    type="text"
                    className="sign__input"
                    placeholder="Email"
                    value={email}
                    onChange={(event) => setEmail(event.target.value)}
                  />
                  <div className="sign__error">{emailError}</div>
                </div>

                <div className="sign__group">
                  <input
                    type="password"
                    className="sign__input"
                    placeholder="Password"
                    value={password}
                    onChange={(event) => setPassword(event.target.value)}
                  />
                  <div className="sign__error">{passwordError}</div>
                </div>

                <div className="sign__group">
                  <input
                    type="text"
                    className="sign__input"
                    placeholder="Genre Preferences"
                    value={genrePreferences}
                    onChange={(event) =>
                      setGenrePreferences(event.target.value)
                    }
                  />
                  <div className="sign__error">{genrePreferencesError}</div>
                </div>

                <div className="sign__group sign__group--checkbox">
                  <input
                    id="remember"
                    name="remember"
                    type="checkbox"
                    checked={remember}
                    onChange={(event) => setRemember(event.target.checked)}
                  />
                  <label htmlFor="remember">
                    I agree to the <Link to="/privacy">Privacy Policy</Link>
                  </label>
                  <div className="sign__error">{rememberError}</div>
                </div>

                <button className="sign__btn" type="submit">
                  Sign up
                </button>

                <span>
                  <span className="signin-span-text">
                    Already have an account?
                  </span>{' '}
                  <Link className="signin-span-link" to="/signin">
                    Sign in!
                  </Link>
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
