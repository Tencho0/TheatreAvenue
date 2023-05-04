import { Card } from '../../Card/Card'
import './SmallCard.scss'

export const SmallCard = ({ item }) => {
  return (
    <div className="col-6 col-sm-4 col-md-3 col-xl-2 theatre-event-item">
      <Card item={item} />
    </div>
  )
}
