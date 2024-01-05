import { Button, Table } from 'react-bootstrap'
import React, { useEffect, useState } from 'react'
import { getAllTodoItem, updateItem } from '../../api/toDoItem/todoItemApi'
import { useAlertMessage } from '../Alert'

export function Item() {
  const [items, setItems] = useState([])
  const [alertObj, setAlertObj] = useState({
    show: false,
    message:'',
    type: 'success'
  })
  const showAlert = useAlertMessage();

  // use for fresh page
  const [freshKey, setFreshKey] = useState(false);

  useEffect(() => {
    getAllTodoItem().then(response => {
      if (response.status === 200) {
        setItems(response.data)
      }
    })
  }, [freshKey])
  const handleMarkAsComplete = (item) => {
    const data = {...item, isCompleted: true}
    updateItem(data).then(response => {
      if (response.status === 200) {
        setAlertObj({
          ...alertObj,
          message: 'add success',
          show: true
        })
      }else {
        setAlertObj({
          ...alertObj,
          message: response.title,
          show: true
        })
      }
      showAlert(alertObj)
      setFreshKey(!freshKey)
    })
  }
  const getItems = () => {
    setFreshKey(!freshKey)
  }
  return (
    <>
      <h1>
        Showing {items.length} Item(s){' '}
        <Button variant="primary" className="pull-right" onClick={() => getItems()}>
          Refresh
        </Button>
      </h1>

      <Table striped bordered hover>
        <thead>
        <tr>
          <th>Id</th>
          <th>Description</th>
          <th>Action</th>
        </tr>
        </thead>
        <tbody>
        {items.map((item) => (
          <tr key={item.id}>
            <td>{item.id}</td>
            <td>{item.description}</td>
            <td>
              <Button variant="warning" size="sm" onClick={() => handleMarkAsComplete(item)}>
                Mark as completed
              </Button>
            </td>
          </tr>
        ))}
        </tbody>
      </Table>
    </>
  )
}