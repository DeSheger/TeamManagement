import React, { ReactNode } from "react";
import { Container, Row } from "react-bootstrap";
import Menu from "../components/Menu";

interface ILayout
{
    children: ReactNode
}

const Layout: React.FC<ILayout> = ({children}) => {

    return (
        <Container fluid>
            <Row>
                <Menu />
            </Row>

            <Row>
                {children}
            </Row>
        </Container>
    );
}

export default Layout;