import { Link } from 'react-router-dom'
import { PremiereCard } from './PremiereCard/PremiereCard'

export const ExpectedPremiere = ({ item }) => {
  return (
    <section className="section section--border">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="owl-carousel section__carousel" id="carousel1">
              <PremiereCard item={item} />
              <PremiereCard item={item} />
              <PremiereCard item={item} />
              <PremiereCard item={item} />
              <PremiereCard item={item} />
              <PremiereCard item={item} />
              <PremiereCard item={item} />
              <PremiereCard item={item} />
            </div>
          </div>
          {/* carousel */}
        </div>
      </div>
    </section>
  )
}
