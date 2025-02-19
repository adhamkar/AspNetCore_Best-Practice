import React, { ReactNode } from 'react';
import Test from './components/Test';
import Navbar from './components/Navbar';

interface LayoutProps {
    children: ReactNode;
}

const Layout:React.FC<LayoutProps> =({children})=>{

    return(
        <div>
        <Navbar />    
        <main>
            {children}
        </main>
        <Test />
        </div>
    )
}
export default Layout;