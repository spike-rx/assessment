
import { Item } from './index'

import {render, cleanup, screen} from '@testing-library/react'

import '@testing-library/jest-dom/extend-expect';

const renderItem = () => render(<Item/>)

afterEach(()=> {
  cleanup()
})
test("UI test", () => {
  renderItem();
  const FormElement = screen.getByText(/Id/i)
  expect(FormElement).toBeInTheDocument();
})