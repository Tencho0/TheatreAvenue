import { Link } from 'react-router-dom'
import './Contacts.scss'

export const Contacts = () => {
  return (
    <div>
      <section className="section section--first section--bg">
        <div className="container">
          <div className="row">
            <div className="col-12">
              <div className="section__wrap">
                <h2 className="section__title">Contacts</h2>

                <ul className="breadcrumb">
                  <li className="breadcrumb__item">
                    <Link to="/">Home</Link>
                  </li>
                  <li className="breadcrumb__item breadcrumb__item--active">
                    Contacts
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section className="section">
        <div className="container">
          <div className="row">
            <div className="col-12 col-md-7 col-xl-8">
              <div className="row">
                <div className="col-12">
                  <h2 className="section__title section__title--mb">
                    Contact Form
                  </h2>
                </div>

                <div className="col-12">
                  <form action="#" className="form form--contacts">
                    <div className="row row--form">
                      <div className="col-12 col-xl-6">
                        <input
                          type="text"
                          className="form__input"
                          placeholder="Name"
                        />
                      </div>
                      <div className="col-12 col-xl-6">
                        <input
                          type="text"
                          className="form__input"
                          placeholder="Email"
                        />
                      </div>
                      <div className="col-12">
                        <input
                          type="text"
                          className="form__input"
                          placeholder="Subject"
                        />
                      </div>
                      <div className="col-12">
                        <textarea
                          id="text"
                          name="text"
                          className="form__textarea"
                          placeholder="Type your message..."
                          defaultValue={''}
                        />
                      </div>
                      <div className="col-12">
                        <button type="button" className="form__btn">
                          Send
                        </button>
                      </div>
                    </div>
                  </form>
                </div>
              </div>
            </div>
            <div className="col-12 col-md-5 col-xl-4">
              <div className="row">
                <div className="col-12">
                  <h2 className="section__title section__title--mb">Info</h2>
                </div>

                <div className="col-12">
                  <p className="section__text">
                    Need to get in touch? We're here to help! We value your
                    feedback and questions. Please don't hesitate to contact us
                    through our support form, by phone or by emailing us. Our
                    support team is always ready to assist you.
                  </p>
                  <ul className="contacts__list">
                    <li>
                      <Link to="tel:+359 888 66 10 68">+359 888 66 10 68</Link>
                    </li>
                    <li>
                      <Link to="mailto:support@moviego.com">
                        theatreavenue@abv.bg
                      </Link>
                    </li>
                  </ul>
                  <div className="contacts__social">
                    <Link
                      to="https://www.facebook.com/profile.php?id=100090966875859&mibextid=ZbWKwL"
                      target="_blank"
                    >
                      <svg
                        width="30"
                        height="30"
                        viewBox="0 0 30 30"
                        fill="none"
                        xmlns="http://www.w3.org/2000/svg"
                      >
                        <path
                          d="M0 15C0 6.71573 6.71573 0 15 0C23.2843 0 30 6.71573 30 15C30 23.2843 23.2843 30 15 30C6.71573 30 0 23.2843 0 15Z"
                          fill="#3B5998"
                        />
                        <path
                          d="M16.5634 23.8197V15.6589H18.8161L19.1147 12.8466H16.5634L16.5672 11.4391C16.5672 10.7056 16.6369 10.3126 17.6904 10.3126H19.0987V7.5H16.8457C14.1394 7.5 13.1869 8.86425 13.1869 11.1585V12.8469H11.4999V15.6592H13.1869V23.8197H16.5634Z"
                          fill="white"
                        />
                      </svg>
                    </Link>
                    <Link
                      to="https://instagram.com/theatreavenue?igshid=ZDdkNTZiNTM="
                      target="_blank"
                    >
                      <svg
                        width="30"
                        height="30"
                        viewBox="0 0 30 30"
                        fill="none"
                        xmlns="http://www.w3.org/2000/svg"
                      >
                        <path
                          d="M0 15C0 6.71573 6.71573 0 15 0C23.2843 0 30 6.71573 30 15C30 23.2843 23.2843 30 15 30C6.71573 30 0 23.2843 0 15Z"
                          fill="white"
                        />
                        <g>
                          <path
                            fillRule="evenodd"
                            clipRule="evenodd"
                            d="M14.9984 7C12.8279 7 12.5552 7.00949 11.7022 7.04834C10.8505 7.08734 10.2692 7.22217 9.76048 7.42001C9.23431 7.62433 8.78797 7.89767 8.3433 8.3425C7.8983 8.78717 7.62496 9.23352 7.41996 9.75952C7.22162 10.2684 7.08662 10.8499 7.04829 11.7012C7.01012 12.5546 7.00012 12.8274 7.00012 15.0001C7.00012 17.1728 7.00979 17.4446 7.04846 18.2979C7.08762 19.1496 7.22246 19.731 7.42013 20.2396C7.62463 20.7658 7.89796 21.2122 8.3428 21.6568C8.78731 22.1018 9.23365 22.3758 9.75948 22.5802C10.2685 22.778 10.85 22.9128 11.7015 22.9518C12.5548 22.9907 12.8273 23.0002 14.9999 23.0002C17.1727 23.0002 17.4446 22.9907 18.2979 22.9518C19.1496 22.9128 19.7316 22.778 20.2406 22.5802C20.7666 22.3758 21.2123 22.1018 21.6568 21.6568C22.1018 21.2122 22.3751 20.7658 22.5801 20.2398C22.7768 19.731 22.9118 19.1495 22.9518 18.2981C22.9901 17.4448 23.0001 17.1728 23.0001 15.0001C23.0001 12.8274 22.9901 12.5547 22.9518 11.7014C22.9118 10.8497 22.7768 10.2684 22.5801 9.7597C22.3751 9.23352 22.1018 8.78717 21.6568 8.3425C21.2118 7.89752 20.7668 7.62418 20.2401 7.42001C19.7301 7.22217 19.1484 7.08734 18.2967 7.04834C17.4434 7.00949 17.1717 7 14.9984 7ZM14.5903 8.44156L14.7343 8.44165L15.0009 8.44171C17.1369 8.44171 17.3901 8.44937 18.2336 8.4877C19.0136 8.52338 19.437 8.65369 19.719 8.76321C20.0923 8.9082 20.3585 9.08154 20.6383 9.36154C20.9183 9.64154 21.0916 9.9082 21.237 10.2816C21.3465 10.5632 21.477 10.9866 21.5125 11.7666C21.5508 12.6099 21.5591 12.8633 21.5591 14.9983C21.5591 17.1333 21.5508 17.3866 21.5125 18.23C21.4768 19.01 21.3465 19.4333 21.237 19.715C21.092 20.0883 20.9183 20.3542 20.6383 20.634C20.3583 20.914 20.0925 21.0873 19.719 21.2323C19.4373 21.3423 19.0136 21.4723 18.2336 21.508C17.3903 21.5463 17.1369 21.5547 15.0009 21.5547C12.8647 21.5547 12.6115 21.5463 11.7682 21.508C10.9882 21.472 10.5649 21.3417 10.2827 21.2322C9.90935 21.0872 9.64268 20.9138 9.36268 20.6338C9.08268 20.3538 8.90934 20.0878 8.76401 19.7143C8.65451 19.4326 8.52401 19.0093 8.48851 18.2293C8.45017 17.386 8.4425 17.1326 8.4425 14.9963C8.4425 12.8599 8.45017 12.6079 8.48851 11.7646C8.52417 10.9846 8.65451 10.5612 8.76401 10.2792C8.90901 9.90588 9.08268 9.63922 9.36268 9.35919C9.64268 9.07919 9.90935 8.90588 10.2827 8.76053C10.5647 8.65054 10.9882 8.52054 11.7682 8.48471C12.5062 8.45135 12.7922 8.44138 14.2832 8.4397V8.44171C14.3803 8.44156 14.4825 8.44153 14.5903 8.44156ZM18.3113 10.7296C18.3113 10.1994 18.7413 9.76987 19.2713 9.76987V9.76953C19.8013 9.76953 20.2313 10.1995 20.2313 10.7296C20.2313 11.2596 19.8013 11.6895 19.2713 11.6895C18.7413 11.6895 18.3113 11.2596 18.3113 10.7296ZM15.0011 10.8916C12.7323 10.8916 10.8928 12.7311 10.8928 15C10.8928 17.2688 12.7323 19.1075 15.0011 19.1075C17.27 19.1075 19.1088 17.2688 19.1088 15C19.1088 12.7311 17.2698 10.8916 15.0011 10.8916ZM17.6678 14.9999C17.6678 13.5271 16.4738 12.3333 15.0011 12.3333C13.5283 12.3333 12.3344 13.5271 12.3344 14.9999C12.3344 16.4726 13.5283 17.6666 15.0011 17.6666C16.4738 17.6666 17.6678 16.4726 17.6678 14.9999Z"
                            fill="black"
                          />
                        </g>
                      </svg>
                    </Link>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  )
}
