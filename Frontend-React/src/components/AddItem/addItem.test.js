
import { AddItem } from './index'

import {render, fireEvent, cleanup, screen} from '@testing-library/react'

import '@testing-library/jest-dom/extend-expect';

const renderAddItem = () => render(<AddItem/>)

afterEach(()=> {
  cleanup()
})
test("UI test", () => {
  renderAddItem();
  const FormElement = screen.getByText(/Description/i)
  expect(FormElement).toBeInTheDocument();
})