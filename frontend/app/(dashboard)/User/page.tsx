'use client'
import { useState, useEffect } from 'react';
import { Button } from 'primereact/button'
import { InputText } from 'primereact/inputtext'

// import './DataFetchers/UserFetcher';
import { fetchUserById, fetchUserByUsername, fetchAllUsers, verifyPassword, updateUser } from '../../DataFetchers/UserFetcher';

interface updateUser {
  email: string,
  password: string
}

export default function Home() {
  const [items, setItems] = useState([]);
  const [userId, setUserId] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [newEmail, setNewEmail] = useState('');


useEffect(() => {
  console.log(items)
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

  const updateUserEmail = async() => {
    const updatedUser: updateUser = {
      email: newEmail, 
      password: newPassword
    }
    setItems(await updateUser(parseInt(userId), updatedUser))
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
      <hr />
      <InputText placeholder='Email Address' value={newEmail} onChange={(e) => setNewEmail(e.target.value)} />
      <InputText placeholder='Password' value={newPassword} onChange={(e) => setNewPassword(e.target.value)} />
      <Button label='Update Email' onClick={() => { updateUserEmail() }} />
      <hr />
      <div>
      </div>
    </>
  );
}