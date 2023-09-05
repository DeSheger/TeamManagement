import { useEffect, useState } from "react";
import getCompanies from "../../services/getCompanies";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import CompanyProfile from "../../components/Company/CompanyProfile";
import { Col, Container, Nav, Row } from "react-bootstrap";


const CompanyIterate = (companies: any, setCompany: Function) => {

    if (companies instanceof Array)
        return companies.map((company: any) => company ? <Nav.Link onClick={() => {
            setCompany(company)
        }}>{company.name}</Nav.Link>
            : null)
    else {
        return "No companies"
    }
}

const Companies = ({ theme }: any) => {
    const [companies, setCompanies] = useState([]);
    const session = useSelector((state: RootState) => state.session)
    const [company, setCompany] = useState({});

    useEffect(() => {
        console.log(session)
        getCompanies(session)
            .then((val) => setCompanies(val))
            .catch((err) => console.log(err))
        console.log(company)
    }, [session, company])

    return (
        <div className="companies">
            <Container fluid>
                <Row>
                    <Col>
                        {CompanyIterate(companies, setCompany)}
                    </Col>
                    <Col>
                        <CompanyProfile selectedCompany={company} theme={theme}/>
                    </Col>
                </Row>
            </Container>
        </div>
    );
}

export default Companies;