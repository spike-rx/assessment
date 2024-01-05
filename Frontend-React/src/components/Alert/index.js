import Alert from 'react-bootstrap/Alert';
import { createContext, useContext, useState } from 'react'

// may use redux in real world

const AlertMessageContext = createContext();


export default function AlertMessageProvider({children}) {

  const [alertObj, setAlertObj] = useState({
    type: '',
    show: false,
    message: '',
  });


  const myStyles = {
    position: 'fixed',
    top: '20px',
    right: '5px',
    zIndex: '9999',
    width: '100%',
    transition: 'all 0.5s ease'
  };


  const showAlert = (alertObj) => {
    setAlertObj(alertObj);

    setTimeout(() => {
      setAlertObj({
        ...alertObj,
        show: false
      })
    }, 1000)

  }
    return (
      <AlertMessageContext.Provider value={showAlert}>
        {children}
        {alertObj.show &&(<Alert style={myStyles} variant={alertObj.type}>
          {alertObj.message}
        </Alert>)}
      </AlertMessageContext.Provider>
    );
}

export const useAlertMessage = () => {
  return useContext(AlertMessageContext);
}