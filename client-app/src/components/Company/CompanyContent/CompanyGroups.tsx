import { Container, Row } from "react-bootstrap";

const CompanyGroups = ({ company }: any) => {
    const companyLeaderName = company?.leader?.name;
    const companyLeaderSurname = company?.leader?.surrname;
    const companyDesc = company?.description;


    return (
        <Container>
            <Row>
                <h4>Leader</h4>
            </Row>
            <Row>
            {`${companyLeaderName} ${companyLeaderSurname}`}
            </Row>
            <Row>
                <h4>Description</h4>
            </Row>
            <Row>
            {companyDesc}
            </Row>
        </Container>
    )
}

export default CompanyGroups;