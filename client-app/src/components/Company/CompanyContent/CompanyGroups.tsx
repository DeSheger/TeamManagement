import { useEffect, useState } from "react";
import { Card, Container, Row } from "react-bootstrap";
import getCompanyGroups from "../../../services/getCompanyGroups";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";

const Group = ({ group }: any) => {
    const groupName = group?.name;
    const groupLeader = group?.leader?.name + " " + group?.leader?.surrname;
    const groupDescription = group?.description;
    const groupMembers = group?.members.map((member: any) => member.name + " " + member.surrname+ ", ")

    return (
        <Card bg="primary" text="light" style={{ width: '18rem', margin:"4px"}}>
            <Card.Body>
                <Card.Title>{groupName}</Card.Title>
                <Card.Subtitle className="mb-2 text-muted">{groupDescription}</Card.Subtitle>
                <Card.Text>
                    <h6>Leader</h6>
                    {groupLeader}
                </Card.Text>
                <Card.Text>
                    <h6>Members</h6>
                    {groupMembers}
                </Card.Text>
            </Card.Body>
        </Card>
    )
}

const CompanyGroups = ({ company }: any) => {
    const [companyGroups, seCompanyGroups] = useState([]);
    const session = useSelector((state: RootState) => state.session)

    useEffect(() => {
        getCompanyGroups(company.id, session)
            .then((val) => seCompanyGroups(val))
            .catch((err) => console.log(err))
    }, [company])

    return (
        <Container>
            <Row>
                {companyGroups.map((group: Object) => <Group group={group} />)}

            </Row>
        </Container>
    )
}

export default CompanyGroups;