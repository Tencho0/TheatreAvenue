export const ReviewsItem = ({ item }) => {
  return (
    <li className="reviews__item">
      <div className="reviews__autor">
        <img className="reviews__avatar" src={item.imgUrl} alt="" />
        <span className="reviews__name">{item.name}</span>
        <span className="reviews__time">{item.time}</span>
        <span className="reviews__rating reviews__rating--red">
          {item.rate}
        </span>
      </div>
      <p className="reviews__text">{item.text}</p>
    </li>
  )
}
