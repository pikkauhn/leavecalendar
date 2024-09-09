'use client'
import RegistrationForm from '@/app/Components/RegistrationForm'
import React from 'react'

const page = () => {
    const handleRegistrationSuccess = () => {
        console.log('Registration successful!');
    }
    return (
        <>
            <RegistrationForm onRegistrationSuccess={handleRegistrationSuccess} />
        </>
    )
}

export default page