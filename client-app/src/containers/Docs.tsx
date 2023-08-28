import React from 'react';
import Layout from './Layout';
import { Col, Container, Row } from 'react-bootstrap';
import Sidebar from '../components/SideBar';

const Docs = ({ theme }: any) => {

    return (
        <div className='docs'>
            <Container fluid>
                <Row>
                    <Col xs={2} className="docs__sidebar">
                        <Sidebar theme={theme}/>
                    </Col>
                    <Col xs={10} className="docs__content">
                        this is a test
                    </Col>
                </Row>
            </Container>
        </div>
    );
};


export default Docs