import { Link } from 'react-router-dom'
import { ComentItem } from './ComentItem/ComentItem'
import { ReviewsItem } from './ReviewsItem/ReviewsItem'
import { GalleryItem } from './GalleryItem/GalleryItem'
import { AverageCard } from '../../../AverageCard/AverageCard'

export const Content = () => {
  let defaultComment = {
    imgUrl: 'img/user.svg',
    name: 'John Doe',
    time: '30.08.2018, 17:53',
    text: "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
    likes: '12',
    dislikes: '7',
    commentType: '',
  }

  let defaultCommentAnswer = {
    imgUrl: 'img/user.svg',
    name: 'John Doe',
    time: '30.08.2018, 17:53',
    text: "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
    likes: '8',
    dislikes: '3',
    commentType: ' comments__item--answer',
  }

  let defaultCommentQuote = {
    imgUrl: 'img/user.svg',
    name: 'John Doe',
    time: '30.08.2018, 17:53',
    text: "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
    likes: '11',
    dislikes: '1',
    commentType: ' comments__item--quote',
  }

  let defaultReviews = [
    {
      imgUrl: 'img/user.svg',
      name: 'Best Marvel movie in my opinion',
      time: '24.08.2018, 17:53 by John Doe',
      text: "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
      rate: '5.5',
    },
  ]

  let defaultGalleryItems = [
    {
      imgUrl: 'img/gallery/project-1.jpg',
      imgCaption: 'Some image caption 1',
    },
  ]

  let cardItems = [
    {
      imgUrl: 'img/covers/cover.jpg',
      rate: '8.4',
      title: 'I Dream in Another Language',
      genres: [
        { url: '#', name: 'Action' },
        { url: '#', name: 'Triler' },
      ],
    },
  ]

  return (
    <section className="content">
      <div className="content__head">
        <div className="container">
          <div className="row">
            <div className="col-12">
              <h2 className="content__title">Discover</h2>

              <ul
                className="nav nav-tabs content__tabs"
                id="content__tabs"
                role="tablist"
              >
                <li className="nav-item">
                  <Link
                    className="nav-link active"
                    data-toggle="tab"
                    to="#tab-1"
                    role="tab"
                    aria-controls="tab-1"
                    aria-selected="true"
                  >
                    Comments
                  </Link>
                </li>
                <li className="nav-item">
                  <Link
                    className="nav-link"
                    data-toggle="tab"
                    to="#tab-2"
                    role="tab"
                    aria-controls="tab-2"
                    aria-selected="false"
                  >
                    Reviews
                  </Link>
                </li>
                <li className="nav-item">
                  <Link
                    className="nav-link"
                    data-toggle="tab"
                    to="#tab-3"
                    role="tab"
                    aria-controls="tab-3"
                    aria-selected="false"
                  >
                    Photos
                  </Link>
                </li>
              </ul>

              <div className="content__mobile-tabs" id="content__mobile-tabs">
                <div
                  className="content__mobile-tabs-btn dropdown-toggle"
                  role="navigation"
                  id="mobile-tabs"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  <input type="button" defaultValue="Comments" />
                  <span />
                </div>
                <div
                  className="content__mobile-tabs-menu dropdown-menu"
                  aria-labelledby="mobile-tabs"
                >
                  <ul className="nav nav-tabs" role="tablist">
                    <li className="nav-item">
                      <Link
                        className="nav-link active"
                        id="1-tab"
                        data-toggle="tab"
                        to="#tab-1"
                        role="tab"
                        aria-controls="tab-1"
                        aria-selected="true"
                      >
                        Comments
                      </Link>
                    </li>
                    <li className="nav-item">
                      <Link
                        className="nav-link"
                        id="2-tab"
                        data-toggle="tab"
                        to="#tab-2"
                        role="tab"
                        aria-controls="tab-2"
                        aria-selected="false"
                      >
                        Reviews
                      </Link>
                    </li>
                    <li className="nav-item">
                      <Link
                        className="nav-link"
                        id="3-tab"
                        data-toggle="tab"
                        to="#tab-3"
                        role="tab"
                        aria-controls="tab-3"
                        aria-selected="false"
                      >
                        Photos
                      </Link>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="container">
        <div className="row">
          <div className="col-12 col-lg-8 col-xl-8">
            <div className="tab-content">
              <div
                className="tab-pane fade show active"
                id="tab-1"
                role="tabpanel"
                aria-labelledby="1-tab"
              >
                <div className="row">
                  <div className="col-12">
                    <div className="comments">
                      <ul className="comments__list">
                        <ComentItem item={defaultComment} />
                        <ComentItem item={defaultCommentAnswer} />
                        <ComentItem item={defaultCommentQuote} />
                        <ComentItem item={defaultComment} />
                        <ComentItem item={defaultComment} />
                      </ul>
                      <form action="#" className="form">
                        <textarea
                          id="text"
                          name="text"
                          className="form__textarea"
                          placeholder="Add comment"
                          defaultValue={''}
                        />
                        <button type="button" className="form__btn">
                          Send
                        </button>
                      </form>
                    </div>
                  </div>
                </div>
              </div>
              <div
                className="tab-pane fade"
                id="tab-2"
                role="tabpanel"
                aria-labelledby="2-tab"
              >
                <div className="row">
                  <div className="col-12">
                    <div className="reviews">
                      <ul className="reviews__list">
                        {defaultReviews &&
                          defaultReviews.map((x, i) => (
                            <ReviewsItem item={x} key={i + 1} />
                          ))}
                      </ul>
                      <form action="#" className="form">
                        <input
                          type="text"
                          className="form__input"
                          placeholder="Title"
                        />
                        <textarea
                          className="form__textarea"
                          placeholder="Review"
                          defaultValue={''}
                        />
                        <div className="form__slider">
                          <div
                            className="form__slider-rating"
                            id="slider__rating"
                          />
                          <div
                            className="form__slider-value"
                            id="form__slider-value"
                          />
                        </div>
                        <button type="button" className="form__btn">
                          Send
                        </button>
                      </form>
                    </div>
                  </div>
                </div>
              </div>
              <div
                className="tab-pane fade"
                id="tab-3"
                role="tabpanel"
                aria-labelledby="3-tab"
              >
                <div className="gallery" itemScope>
                  <div className="row row--grid">
                    {defaultGalleryItems &&
                      defaultGalleryItems.map((x, i) => (
                        <GalleryItem item={x} key={i + 1} />
                      ))}
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div className="col-12 col-lg-4 col-xl-4">
            <div className="row row--grid">
              <div className="col-12">
                <h2 className="section__title section__title--sidebar">
                  You may also like...
                </h2>
              </div>
              {cardItems &&
                cardItems.map((x, i) => <AverageCard item={x} key={i + 1} />)}
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}
