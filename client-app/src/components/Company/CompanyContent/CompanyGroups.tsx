import { useEffect, useState } from "react";
import { Container, Row } from "react-bootstrap";
import getCompanyGroups from "../../../services/getCompanyGroups";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";

const Group = ({group}:any) => {
    const groupName = group?.name;
    const groupLeader = group?.leader?.name;
    const groupDescription = group?.description;
    const groupMembers = group?.members.map((member:any) => member.name+" ")

    return(
        <Container>
            <Row>
                <h6>Name</h6>
                {groupName}
            </Row>
            <Row>
                <h6>Leader</h6>
                {groupLeader}
            </Row>
            <Row>
                <h6>Description</h6>
                {groupDescription}
            </Row>
            <Row>
                <h6>Members</h6>
                {groupMembers}
            </Row>

        </Container>
    )
}

const CompanyGroups = ({ company }: any) => {
    const [companyGroups, seCompanyGroups] = useState([]);
    const session = useSelector((state:RootState) => state.session)

    useEffect(() => {
        getCompanyGroups(company.id, session)
            .then((val) => seCompanyGroups(val))
            .catch((err) => console.log(err))
    },[company])

    return (
        <Container>
            <Row>
               {companyGroups?.map((group:Object) => <Group group={group}/>)}
            
            </Row>
        </Container>
    )
}

export default CompanyGroups;