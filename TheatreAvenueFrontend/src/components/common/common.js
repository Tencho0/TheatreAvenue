export const setLoginAndRegisterUserData = (data) => {
  localStorage.setItem('AuthToken', data.authData.token)
  localStorage.setItem(
    'AuthTokenExpirationTime',
    data.authData.tokenExpirationTime
  )
  localStorage.setItem('AuthUniqueToken', data.authData.uniqueToken)
  localStorage.setItem('UserIsAdmin', data.userData.isAdmin)
  localStorage.setItem('UserEmail', data.userData.email)
  localStorage.setItem(
    'BookedTheatreEventsIds',
    data.userData.bookedTheatreEventsIds
  )
  localStorage.setItem('Preferences', data.userData.preferences)
  localStorage.setItem(
    'ReccomendedTheatreEvents',
    JSON.stringify(data.userData.reccomendedTheatreEvents)
  )
  localStorage.setItem(
    'ReccomendedSeatNumbers',
    JSON.stringify(data.userData.reccomendedSeatNumbers)
  )
  localStorage.setItem('OpenTheatreEventReccomandationModal', true)
}

export const logout = () => {
  localStorage.clear()
  window.location.replace('/')
}

export const isUserAdmin = () => {
  const userIsAdmin = localStorage.getItem('UserIsAdmin')
  return userIsAdmin !== null
}

export const isUserLoggedIn = () => {
  const authToken = localStorage.getItem('AuthToken')
  return authToken !== null
}
