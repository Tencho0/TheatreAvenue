import { PageTitle } from '../PageTitle/PageTitle'
import './FAQ.scss'

export const FAQ = () => {
  return (
    <div>
      <PageTitle title="FAQ" />
      <section className="section section--top">
        <div className="container">
          <div className="row">
            <div className="col-12 col-md-6">
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> How
                  do I book tickets for a theatre performance?
                </h3>
                <p className="faq__text">
                  You first need to select a theatre performance you like, then
                  press on the seat map, choose a seat and book it.
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> Can
                  I choose my seats when booking tickets?
                </h3>
                <p className="faq__text">
                  Of course, there is a seat map for every performance, where
                  users can choose and book their own seats.
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> What
                  payment methods do you accept?
                </h3>
                <p className="faq__text">
                  Our website is just a tool for booking the tickets. After
                  booking the user receives the ticket in an email and can buy
                  it on the spot and the location of the venue.
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> How
                  will I receive my tickets after I make a booking?
                </h3>
                <p className="faq__text">
                  People who have booked any tickets will receive them in their
                  provided email.
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> What
                  if I need to cancel or change my booking?
                </h3>
                <p className="faq__text">
                  You can cancel or change the booking any time before the 30
                  minutes before the performance starts.
                </p>
              </div>
            </div>
            <div className="col-12 col-md-6">
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> Is
                  there a fee for cancelling or changing my booking?
                </h3>
                <p className="faq__text">
                  There is no fee in cancelling or changing the booking but you
                  risk losing your ticket and any future benefits that the
                  website provides.
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> What
                  if the performance I booked is cancelled or rescheduled?
                </h3>
                <p className="faq__text">
                  If the performance you have booked is cancelled or rescheduled
                  you will be notified at least 24 hours before it, so that you
                  can change your bookings accordingly
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> Are
                  there discounts available for group bookings?
                </h3>
                <p className="faq__text">
                  Yes, we provide plenty of discount packages. You can check
                  them out in our discounts field.
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> Can
                  I buy tickets at the theatre box office instead of online?
                </h3>
                <p className="faq__text">
                  Our website does not provide purchases made online, so it is
                  necessary that you buy the tickets in the theatre itself.
                </p>
              </div>
              <div className="faq">
                <h3 className="faq__title">
                  <i className="icon ion-ios-information-circle-outline" /> Do
                  you offer gift certificates or vouchers?
                </h3>
                <p className="faq__text">
                  We provide vouchers and discounts to people that have gained
                  some benefits with their past bookings. You can also check out
                  our discount packages.
                </p>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  )
}
