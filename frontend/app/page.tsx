'use client'
import { useState } from 'react';
import { Button } from 'primereact/button'


export default function Home() {
  const [items, setItems] = useState([]);

  const getUsers = async () => {
    try {
      const response = await fetch('http://localhost:5031/api/user', {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        }
      })
      if (!response.ok) {
        throw new Error(`Failed to fetch data. Status: ${response.status}`);
      }
      return response.json();
    } catch (error) {
      console.error('Get Users Error: ', error);
    }
  }

  const setUsers = async () => {
    setItems(await getUsers());
    console.log(items);
  }

  return (
    <>
      <Button label="test" onClick={() => { setUsers() }}/>
    </>
  );
}
