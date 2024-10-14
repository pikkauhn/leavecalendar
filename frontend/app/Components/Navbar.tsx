
import React from 'react'; 
import { Menubar } from 'primereact/menubar';
import { MenuItem } from 'primereact/menuitem';

export default function Navbar() {
    const items: MenuItem[] = [
        {
            label: 'Home',
            icon: 'pi pi-home',
            url: '/'
        },
        {
            label: 'Register',
            icon: 'pi pi-star',
            url: '/Register'
        },
        {
            label: 'Users',
            icon: 'pi pi-search',
            url: '/User'
            
        },
        {
            label: 'LeaveRequest',
            icon: 'pi pi-envelope',
            url: '/LeaveRequest'
        }
    ];
    
    return (
        <div className="card">
            <Menubar model={items} />
        </div>
    )
}
        