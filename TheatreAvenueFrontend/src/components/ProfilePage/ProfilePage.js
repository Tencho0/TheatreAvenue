import React, { useEffect, useState } from 'react'
import { isUserLoggedIn } from '../common/common'
import CircularIndeterminate from '../common/spinner'
import axios from 'axios'
import './ProfilePage.scss'

export const ProfilePage = () => {
  const [name, setName] = useState('')
  const [sureName, setSureName] = useState('')
  const [email, setEmail] = useState('')
  const [remember, setRemember] = useState(true)
  const [genrePreferences, setGenrePreferences] = useState('')
  const [nameError, setNameError] = useState('')
  const [sureNameError, setSureNameError] = useState('')
  const [emailError, setEmailError] = useState('')
  const [rememberError, setRememberError] = useState('')
  const [ProfileError, setProfileError] = useState('')
  const [genrePreferencesError, setGenrePreferencesError] = useState('')
  const [showSpinner, setShowSpinner] = useState(false)
  const loggedIn = isUserLoggedIn()

  useEffect(() => {
    if (!loggedIn) {
      window.location.replace('/signin')
    }
  }, [])

  useEffect(() => {
    setShowSpinner(true)
    const email = localStorage.getItem('UserEmail')

    axios
      .get(`${process.env.REACT_APP_API_URL}/Users?email=${email}`, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem('AuthToken')}`,
        },
      })
      .then((response) => {
        setEmail(response.data.email)
        setName(response.data.name)
        setSureName(response.data.sureName)
        setGenrePreferences(response.data.preferences)
        setShowSpinner(false)
      })
      .catch((error) => {
        console.error(error)
        navigate('/error')
      })
  }, [])

  const sendProfileApiCall = () => {
    setShowSpinner(true)
    // UPDATE PROFILE
    axios
      .put(
        `${process.env.REACT_APP_API_URL}/Users/update/${email}`,
        {
          name: name,
          sureName: sureName,
          email: email,
          preferences: genrePreferences,
        },
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('AuthToken')}`,
          },
        }
      )
      .then((response) => {
        localStorage.setItem('Preferences', genrePreferences)
        setShowSpinner(false)
      })
      .catch((error) => {
        setShowSpinner(false)
        console.error(error)
        if (error.response.status === 500) {
          navigate('/error')
        }
        setProfileError(error.response.data)
      })
  }

  const handleSubmit = (event) => {
    event.preventDefault()

    // Validation rules
    const namePattern = /^[a-zA-Z\s]*$/
    const emailPattern = /^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/
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

    // Genre Preferences
    if (!genrePreferences && genrePreferences === ' ') {
      setGenrePreferencesError('Name is required')
      return
    } else if (!genrePreferencesPattern.test(genrePreferences)) {
      setGenrePreferencesError('Name can only contain letters and spaces')
      return
    } else {
      setGenrePreferencesError('')
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

    // Remember checkbox validation
    if (!remember) {
      setRememberError('You must agree to the Privacy Policy')
      return
    } else {
      setRememberError('')
    }

    sendProfileApiCall()
  }

  return (
    <div className="container-profile">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="sign__content">
              <form onSubmit={handleSubmit} className="sign__form">
                <h1 className="profileHeader">Your Profile</h1>
                <div className="sign__error">{ProfileError}</div>
                <br />
                <div className="sign__group">
                  <input
                    type="text"
                    className="sign__input profile-page-email"
                    placeholder="Email"
                    value={email}
                    disabled
                    onChange={(event) => setEmail(event.target.value)}
                  />
                  <div className="sign__error">{emailError}</div>
                </div>

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
                  <div className="sign__error">{rememberError}</div>
                </div>

                <button className="sign__btn" type="submit">
                  Update Profile
                </button>
              </form>

              {showSpinner && CircularIndeterminate()}
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
