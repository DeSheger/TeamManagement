import React from "react";
import {Nav} from "react-bootstrap";

const Sidebar = (theme:any) => {
   

    return (
        <>
    
            <Nav className={`col-md-12 d-none d-md-block bg-${theme} text_${theme} sidebar`}
            activeKey="/home"
            onSelect={selectedKey => alert(`selected ${selectedKey}`)}
            >
                <div className="sidebar-sticky"></div>
            <Nav.Item>
                <Nav.Link >Get Started</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link>Company</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link>Group</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link>Activity</Nav.Link>
            </Nav.Item>
            </Nav>
        </>
        );
  };

  export default Sidebar;