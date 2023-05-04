import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { Contacts } from '../Contacts/Contacts'
import { FAQ } from '../FAQ/FAQ'
import { Footer } from '../Footer/Footer'
import { Header } from '../Header/Header'
import { NotFound } from '../NotFound/NotFound'
import { Home } from '../Home/Home'
import { PrivacyPolicy } from '../PrivacyPolicy/PrivacyPolicy'
import { SignIn } from '../SignIn/SignIn'
import { SignUp } from '../SignUp/SignUp'
import { Details } from '../Details/Details'
import { Hall } from '../Hall/Hall'
import { ErrorPage } from '../Error/Error'
import { ProfilePage } from '../ProfilePage/ProfilePage'

export const TheatreRouter = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/signup" element={<SignUp />} />
        <Route path="/profile" element={<ProfilePage />} />
        <Route path="/signin" element={<SignIn />} />
        <Route path="/contacts" element={<Contacts />} />
        <Route path="/privacy" element={<PrivacyPolicy />} />
        <Route path="/hall/:id" element={<Hall />} />
        <Route path="/faq" element={<FAQ />} />
        <Route path="/details/:id" element={<Details />} />
        <Route path="/error" element={<ErrorPage />} />
        <Route path="/404" element={<NotFound />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
      <Footer />
    </BrowserRouter>
  )
}
