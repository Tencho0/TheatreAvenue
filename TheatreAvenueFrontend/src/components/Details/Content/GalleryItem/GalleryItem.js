import { Link } from 'react-router-dom'

export const GalleryItem = ({ item }) => {
  return (
    <figure
      className="col-12 col-sm-6 col-xl-4"
      itemProp="associatedMedia"
      itemScope
    >
      <Link to={item.imgUrl} itemProp="contentUrl" data-size="1920x1280">
        <img src={item.imgUrl} itemProp="thumbnail" alt="Image description" />
      </Link>
      <figcaption itemProp="caption description">{item.imgCaption}</figcaption>
    </figure>
  )
}
