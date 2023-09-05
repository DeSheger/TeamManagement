import { useState } from "react";
import CompanyInfo from "../CompanyContent/CompanyInfo";
import { Container, Nav, Navbar, Row } from "react-bootstrap";
import CompanyGroups from "../CompanyContent/CompanyGroups";

const CompanyNavigator = ({ company, theme }: any) => {
    const [content, setContent] = useState({
        info: true,
        members: false,
        groups: false,
        activities: false
    });

    const contentHandler = (name: string) => {
        setContent({
            info: name=="info"?true:false,
            members: name=="members"?true:false,
            groups: name=="groups"?true:false,
            activities: name=="activities"?true:false,
        })
    }

    return (

        <Container>
            <Row>
                <Navbar bg={theme} data-bs-theme={theme}>
                    <Container>
                        <Nav className="me-auto">
                            <Nav.Link onClick={() => contentHandler("info")}>Info</Nav.Link>
                            <Nav.Link onClick={() => contentHandler("groups")}>Groups</Nav.Link>
                            <Nav.Link onClick={() => contentHandler("members")}>Activities</Nav.Link>
                            <Nav.Link onClick={() => contentHandler("activities")}>Members</Nav.Link>
                        </Nav>
                    </Container>
                </Navbar>
            </Row>
            
            <Row>
                {content.info ? <CompanyInfo company={company} /> : null}
                {content.groups ? <CompanyGroups company={company} /> : null}
            </Row>
        </Container>
    )
}

export default CompanyNavigator;