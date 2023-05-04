export const ComentItem = ({ item }) => {
  return (
    <li className={'comments__item' + item.commentType}>
      <div className="comments__autor">
        <img className="comments__avatar" src={item.imgUrl} alt="" />
        <span className="comments__name">{item.name}</span>
        <span className="comments__time">{item.time}</span>
      </div>
      <p className="comments__text">{item.text}</p>
      <div className="comments__actions">
        <div className="comments__rate">
          <button type="button">
            <i className="icon ion-md-thumbs-up" />
            {item.likes}
          </button>
          <button type="button">
            {item.dislikes}
            <i className="icon ion-md-thumbs-down" />
          </button>
        </div>
        <button type="button">
          <i className="icon ion-ios-share-alt" />
          Reply
        </button>
        <button type="button">
          <i className="icon ion-ios-quote" />
          Quote
        </button>
      </div>
    </li>
  )
}
