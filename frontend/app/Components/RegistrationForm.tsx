'use client'
import React, { useState, useEffect } from 'react';
import { Panel } from 'primereact/panel';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import { Button } from 'primereact/button';

import { createUser } from '../DataFetchers/UserFetcher';
import { AuthenticateCode } from '../DataFetchers/InvitationCodeFetcher';

interface RegistrationFormProps {
    onRegistrationSuccess: () => void;
};

const RegistrationForm: React.FC<RegistrationFormProps> = ({ onRegistrationSuccess }) => {
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [verifyPassword, setVerifyPassword] = useState('');
    const [name, setName] = useState('');
    const [invitationCode, setInvitationCode] = useState('');
    const [selectedDepartment, setSelectedDepartment] = useState<Department>();
    const departments = [
        { id: 1, name: 'ADM' },
        { id: 2, name: 'GPS' },
        { id: 3, name: 'MTR' },
        { id: 4, name: 'OFF' },
        { id: 5, name: 'S/S' },
        { id: 6, name: 'W/S' },
        { id: 7, name: 'WTP' },
        { id: 8, name: 'WWTP' },
    ]

    const handleSubmit = async () => {
        const departmentId = selectedDepartment?.id as number;
        const role = 1;
        try {
            if (!verifyPasswords(password, verifyPassword)) {
                console.error('Passwords do not match');
                return;
            }
            const newUser = {
                email,
                username,
                password,
                name,
                role,
                departmentId,
            };
            const invited = await AuthenticateCode(invitationCode);
            if (invited) {
                const createdUser = await createUser(newUser);
                if (createdUser) {
                    onRegistrationSuccess();
                    
                }
            }

        } catch (error) {
            console.error('Registration error: ', error);
        }
    };

    function verifyPasswords(password1: string, password2: string): boolean {
        return password1 === password2;
    }

    return (
        <div className="registration-form">
            <Panel style={{ width: '300px', margin: 'auto', marginTop: '10px' }} header="New User Registration">
                <form id="registrationForm" onSubmit={handleSubmit}>
                    <div className="p-fluid">
                        <InputText
                            className='registerPageInput'
                            id="username"
                            name="username"
                            required
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                            placeholder="Username"
                        />
                        <InputText
                            className='registerPageInput'
                            id="email"
                            type="email"
                            name="email"
                            required
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="Email Address"
                        />
                        <InputText
                            className='registerPageInput'
                            id="password"
                            type="password"
                            name="password"
                            required
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder="Password"
                        />
                        <InputText
                            className='registerPageInput'
                            id="verifyPassword"
                            type="password"
                            name="verifyPassword"
                            required
                            value={verifyPassword}
                            onChange={(e) => setVerifyPassword(e.target.value)}
                            placeholder="Verify Password"
                        />
                        <InputText
                            className='registerPageInput'
                            id="name"
                            name="name"
                            required
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            placeholder="Full Name"
                        />
                        <InputText
                            className='registerPageInput'
                            id='InvitationCode'
                            name="InvitationCode"
                            required
                            value={invitationCode}
                            onChange={(e) => setInvitationCode(e.target.value)}
                            placeholder="Invitation Code"
                        />
                        <Dropdown
                            className='registerPageDrop'
                            id="departments"
                            name="departments"
                            required
                            optionLabel="name"
                            options={departments}
                            value={selectedDepartment}
                            onChange={(e) => setSelectedDepartment(e.value)}
                            placeholder='Select a department'
                        />
                        <Button type='button' label='Submit' onClick={handleSubmit} />
                    </div>
                </form>
            </Panel>
        </div>
    )
}

export default RegistrationForm;