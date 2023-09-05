import { useEffect, useState } from "react";
import CompanyNavigator from "./CompanyNavigator/CompanyNavigator";
import getCompany from "../../services/getCompany";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import { Container, Row } from "react-bootstrap";

const CompanyProfile = ({selectedCompany, theme}:any) => {
    const [company, setCompany] = useState({});
    const session = useSelector((state:RootState) => state.session)
    const [companyName, setCompanyName] = useState(selectedCompany.name);

    useEffect(()=>{
        getCompany(selectedCompany.id,session)
            .then((val) => setCompany(val))
            .catch((er) => console.log(er))
        setCompanyName(selectedCompany.name)
    },[selectedCompany.id])


    return (
        <Container>
            <Row>
                <h2>{companyName}</h2>
            </Row>
            <Row>
                <CompanyNavigator company={company} theme={theme}/> 
            </Row>
        </Container>
    )
}

export default CompanyProfile;