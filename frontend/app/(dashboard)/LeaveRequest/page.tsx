'use client'
import React from 'react'
import { useState, useEffect } from 'react'
import { Button } from 'primereact/button'
import { InputText } from 'primereact/inputtext'
import { fetchAllLeaveRequests, fetchLeaveRequestByUserId, updateLeaveRequest } from '@/app/DataFetchers/LeaveRequestFetcher'

export default function Page() {
  const [items, setItems] = useState([]);
  const [Id, setId] = useState('');
  const [leaveRequest, setLeaveRequest] = useState<UpdateLeaveRequestDto>();
  const [userId, setUserId] = useState('');
  const [reason, setReason] = useState('');
  const [startDate, setStartDate] = useState('');
  const [endDate, setEndDate] = useState('');
  const [status, setStatus] = useState('');
  const [leaveType, setLeaveType] = useState('');
  const [comment, setComment] = useState('');
  const [responseByUserId, setResponseByUserId] = useState('');

  useEffect(() => {
    console.log(items);
  }, [items]);

  const allRequests = async () => {
    setItems(await fetchAllLeaveRequests());
  };

  const userRequests = async () => {
    setItems(await fetchLeaveRequestByUserId(parseInt(userId)));
  }

  const updateUserRequest = async () => {
    if (leaveRequest) {
      setItems(await updateLeaveRequest(parseInt(Id), leaveRequest));
    }
  }

  return (
    <>
      <Button label="Get all requests" onClick={() => { allRequests() }} />
      <InputText placeholder="User Id" value={userId} keyfilter='int' onChange={(e) => setUserId(e.target.value)} />
      <Button label="Get requests by user" onClick={() => { userRequests() }} />
      <hr />
      <InputText placeholder="Id" value={Id} keyfilter='int' onChange={(e) => setId(e.target.value)} />
      <InputText placeholder='Reason' value={reason} onChange={(e) => setReason(e.target.value)} />
      <InputText placeholder='Start Date' value={startDate} onChange={(e) => setStartDate(e.target.value)} />
      <InputText placeholder='End Date' value={endDate} onChange={(e) => setEndDate(e.target.value)} />
      <InputText placeholder='Status' value={status} onChange={(e) => setStatus(e.target.value)} />
      <InputText placeholder='leaveType' value={leaveType} onChange={(e) => setLeaveType(e.target.value)} />
      <InputText placeholder='comment' value={comment} onChange={(e) => setComment(e.target.value)} />
      <InputText placeholder='responseByUserId' value={responseByUserId} onChange={(e) => e.target.value} />
      <Button label="Update Request" onClick={() => { updateUserRequest() }} />
    </>
  );
}