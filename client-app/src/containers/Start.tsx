import React from 'react';
import Layout from './Layout';
import { Button, Card, Row, Stack } from 'react-bootstrap';

const Start = ({theme}:any) => {

    return (
        <div className='start'>
            <section className='start__companySection'>
            <p className={`text_${theme} start__paragraph`}>The process of creating a company involves multiple components, from establishing the business structure to setting up financial systems and operational workflows. By incorporating APIs into these processes, entrepreneurs can experience a more streamlined and automated approach to managing their ventures.</p>
            <Card style={{margin:"5px 0", height:"auto" }} bg={theme} data-bs-theme={theme}>
                <Card.Img variant="top" src="https://cdn.pixabay.com/photo/2015/05/13/01/59/business-764929_1280.jpg" />
                <Card.Body>
                    <Card.Title>Create Company</Card.Title>
                    <Card.Text>          
                        This application allows you to create your own business that you can manage 
                    </Card.Text>
                    <Button variant="primary">Go</Button>
                </Card.Body>
            </Card>
            </section>
            <section className='start__groupSection'>
            <Card style={{margin:"5px 0", height:"auto" }} bg={theme} data-bs-theme={theme}>
                <Card.Img variant="top" src="https://cdn.pixabay.com/photo/2015/05/13/01/59/business-764929_1280.jpg" />
                <Card.Body>
                    <Card.Title>Create Group</Card.Title>
                    <Card.Text>
                        Create groups to easily organize your business
                    </Card.Text>
                    <Button variant="primary">Go</Button>
                </Card.Body>
            </Card>
            <p className={`text_${theme} start__paragraph`}>The process of creating a company involves multiple components, from establishing the business structure to setting up financial systems and operational workflows. By incorporating APIs into these processes, entrepreneurs can experience a more streamlined and automated approach to managing their ventures.</p>
            </section>
            <section className='start__activitySection'>
            <p className={`text_${theme} start__paragraph`}>The process of creating a company involves multiple components, from establishing the business structure to setting up financial systems and operational workflows. By incorporating APIs into these processes, entrepreneurs can experience a more streamlined and automated approach to managing their ventures.</p>
            <Card style={{margin:"5px 0", height:"auto" }} bg={theme} data-bs-theme={theme}>
                <Card.Img variant="top" src="https://cdn.pixabay.com/photo/2015/05/13/01/59/business-764929_1280.jpg" />
                <Card.Body>
                    <Card.Title>Create Activities</Card.Title>
                    <Card.Text>
                        Create activities for individual company members and groups. Set time and resources for each activity. lorem ipsum lorm
                    </Card.Text>
                    <Button variant="primary">Go</Button>
                </Card.Body>
            </Card>
            </section>
        </div>
    );
}

export default Start