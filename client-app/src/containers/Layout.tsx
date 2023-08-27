import React, { ReactNode } from "react";
import { Container, Row } from "react-bootstrap";
import Menu from "../components/Menu";
import { useSelector } from "react-redux";
import { RootState } from "../app/store";

interface ILayout
{
    children: ReactNode
}

const Layout: React.FC<ILayout> = ({children}) => {
    const {theme} = useSelector((state: RootState) => state.theme)
    return (
        <Container fluid>
            <Row>
                <Menu />
            </Row>

            <Row>
                <Container className={`bg-${theme}`} fluid style={{minHeight: "100vh"}}>
                    {children}
                </Container>
            </Row>
        </Container>
    );
}

export default Layout;