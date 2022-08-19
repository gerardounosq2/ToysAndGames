import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import { Button, Confirm, Table } from "semantic-ui-react";
import { ToysAndGames } from "../app/models/ToysAndGames";
import { history } from "../main";
import { useStore } from "../stores/store";

const GridComponent = () => {
    const { productStore } = useStore();
    const { getAllProducts, products, deleteProduct } = productStore;

    useEffect(() => {
        if (products.length === 0)
            getAllProducts();
    }, [products.length, getAllProducts])

    const [confirm, setConfirm] = useState<boolean>(false);

    const show = () => setConfirm(true);
    const close = () => setConfirm(false);

    return (
        <>
            <Button as={NavLink} to={'/create'} content="Add New" />
            <Table celled singleLine>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.HeaderCell>Name</Table.HeaderCell>
                        <Table.HeaderCell>Age</Table.HeaderCell>
                        <Table.HeaderCell>Price</Table.HeaderCell>
                        <Table.HeaderCell>Company</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>
                <Table.Body>
                    {products.map(r => (
                        <Table.Row key={r.id}>
                            <Table.Cell>{r.id}</Table.Cell>
                            <Table.Cell>{r.name}</Table.Cell>
                            <Table.Cell>{r.ageRestriction}</Table.Cell>
                            <Table.Cell>{r.price}</Table.Cell>
                            <Table.Cell>{r.companyName}</Table.Cell>
                            <Table.Cell></Table.Cell>
                            <Table.Cell><Button as={Link} to={`/edit/${r.id}`} content="Update" /></Table.Cell>
                            <Table.Cell><Button basic inverted color="red" content="Delete" onClick={show} /></Table.Cell>
                            <Confirm
                                open={confirm}
                                onCancel={close}
                                onConfirm={() => deleteProduct(r.id)}
                                cancelButton='Cancel'
                                content='Are you sure you wish to delete this record?' />
                        </Table.Row>
                    ))}
                </Table.Body>
            </Table>
        </>
    )
}

export default observer(GridComponent);