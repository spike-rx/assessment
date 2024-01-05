import { Button, Col, Container, Form, Row, Stack} from 'react-bootstrap'
import React, { useState } from 'react'
import { AddTodoItem } from '../../api/toDoItem/todoItemApi'
import { useAlertMessage } from '../Alert'

export function AddItem() {
  const [description, setDescription] = useState('')
  const [alertObj, setAlertObj] = useState({
    show: false,
    message:'',
    type: 'success'
  })
  const showAlert = useAlertMessage();
  const handleDescriptionChange = (e) => {
    setDescription(e.target.value)
  }

  const handleAdd = () => {
    const data = {
      'description': description,
      isCompleted: true
    }
    AddTodoItem(data).then(response => {
      if (response.status === 201) {
        setAlertObj({
          ...alertObj,
          message: 'add success',
          show: true
        })
        // window.location.reload();
      }else {
        setAlertObj({
          ...alertObj,
          message: response.title,
          show: true
        })
      }
    })
    setDescription('')

    showAlert(alertObj)
  }

  function handleClear() {
    setDescription('')
  }

  return (
    <Container>
      <h1>Add Item</h1>
      <Form.Group as={Row} className="mb-3" controlId="formAddTodoItem">
        <Form.Label column sm="2">
          Description
        </Form.Label>
        <Col md="6">
          <Form.Control
            type="text"
            placeholder="Enter description..."
            value={description}
            onChange={handleDescriptionChange}
          />
        </Col>
      </Form.Group>
      <Form.Group as={Row} className="mb-3 offset-md-2" controlId="formAddTodoItem">
        <Stack direction="horizontal" gap={2}>
          <Button variant="primary" onClick={() => handleAdd()}>
            Add Item
          </Button>
          <Button variant="secondary" onClick={() => handleClear()}>
            Clear
          </Button>
        </Stack>
      </Form.Group>
    </Container>
  )
}