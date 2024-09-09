'use client'
import { useState, useEffect } from 'react';
import { Button } from 'primereact/button'
import { InputText } from 'primereact/inputtext'

import './DataFetchers/UserFetcher';
import { fetchUserById, fetchUserByUsername, fetchAllUsers, verifyPassword } from './DataFetchers/UserFetcher';


export default function Home() {
  const [items, setItems] = useState([]);
  const [userId, setUserId] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  useEffect(() => {
    if (items != null) {
      console.log(items)
    }
  }, [items])

  const allUsers = async () => {
    setItems(await fetchAllUsers());
  }

  const userById = async () => {
    setItems(await fetchUserById(parseInt(userId)));
  }

  const userByUsername = async () => {
    setItems(await fetchUserByUsername(username));
  }

  const verifyPass = async () => {
    const user = {
      username,
      password
    }
    console.log(user)
    setItems(await verifyPassword(user));
  }

  return (
    <>
      <Button label="Get all users" onClick={() => { allUsers() }} />
      <InputText placeholder='User Id' value={userId} keyfilter='int' onChange={(e) => setUserId(e.target.value)} />
      <Button label="Get user by Id" onClick={() => { userById() }} />
      <InputText placeholder='Username' value={username} onChange={(e) => setUsername(e.target.value)} />
      <Button label="Get user by Username" onClick={() => { userByUsername() }} />
      <InputText placeholder='Verify' value={password} onChange={(e) => setPassword(e.target.value)} />
      <Button label="Verify Passwords" onClick={() => { verifyPass() }} />
    </>
  );
}
