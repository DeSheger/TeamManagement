import { useState } from "react";
import CompanyInfo from "../CompanyContent/CompanyInfo";
import { Container, Nav, Navbar, Row } from "react-bootstrap";

const CompanyNavigator = ({ company, theme }: any) => {
    const [content, setContent] = useState({
        info: true,
        members: false,
        groups: false,
        activities: false
    });

    return (

        <Container>
            <Row>
                <Navbar bg={theme} data-bs-theme={theme}>
                    <Container>
                        <Nav className="me-auto">
                            <Nav.Link>Info</Nav.Link>
                            <Nav.Link>Groups</Nav.Link>
                            <Nav.Link>Activities</Nav.Link>
                            <Nav.Link>Members</Nav.Link>
                        </Nav>
                    </Container>
                </Navbar>
            </Row>
            
            <Row>
                {content.info ? <CompanyInfo company={company} /> : null}
            </Row>
        </Container>
    )
}

export default CompanyNavigator;