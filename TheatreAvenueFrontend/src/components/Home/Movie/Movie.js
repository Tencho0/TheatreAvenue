import { Card } from '../../../Card/Card'

export const Movie = ({ item }) => {
  return (
    <div className="card card--big">
      <Card item={item} />
    </div>
  )
}
