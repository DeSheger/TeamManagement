import React, { ReactNode } from "react";

interface ILayout
{
    children: ReactNode
}

const Layout: React.FC<ILayout> = ({children}) => {

    return (
        <div className="layout">
            <div className="layout__main">
                {children}
            </div>
        </div>
    );
}

export default Layout;