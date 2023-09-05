import { useEffect, useState } from "react";
import { Container, Row } from "react-bootstrap";
import getCompanyGroups from "../../../services/getCompanyGroups";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";

const CompanyGroups = ({ company }: any) => {
    const [companyGroups, seCompanyGroups] = useState([]);
    const session = useSelector((state:RootState) => state.session)

    useEffect(() => {
        getCompanyGroups(company.id, session)
            .then((val) => console.log(val))
            .catch((err) => console.log(err))
    },[])

    return (
        <Container>
            <Row>
                <h4>Leader</h4>
            </Row>
            <Row>
            
            </Row>
            <Row>
                <h4>Description</h4>
            </Row>
            <Row>
            
            </Row>
        </Container>
    )
}

export default CompanyGroups;