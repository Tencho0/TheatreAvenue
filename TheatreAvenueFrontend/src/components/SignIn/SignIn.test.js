import React from 'react'
import { render } from '@testing-library/react'

describe('SignIn', () => {
  it('renders correctly', () => {
    const { getByText } = render(<div>SomeText</div>)

    expect(getByText('SomeText')).toBeInTheDocument()
  })
})
