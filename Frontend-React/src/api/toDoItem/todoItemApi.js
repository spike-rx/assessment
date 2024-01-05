import {get, post, put} from '../api'

export function getAllTodoItem() {
  return get("/TodoItem")
}

export function getTodoItem(id) {
  return get("/TodoItem/" + id)
}

export function updateItem(data) {
  return put("/TodoItem", data)
}

export function AddTodoItem(data){
  return post("TodoItem", data)
}


