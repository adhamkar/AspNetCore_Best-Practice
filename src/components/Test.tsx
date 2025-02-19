import React, {  useEffect, useState } from 'react';
import { Button, Input, Space, Table, Tag,Form,TableProps,Radio } from 'antd';
import { getProducts } from '../api/Products/ProductApi';
import {  DeleteTwoTone, EditTwoTone } from '@mui/icons-material';
import { InfoCircleOutlined } from '@ant-design/icons';



interface DataType {
  id: number;
  name: string;
  description: string;
  price: number;
  quantityStock: number;
  tags: string[];
}


const Test: React.FC = () => {

  const [form] = Form.useForm();
 

  const [products, setProducts] = useState<DataType[]>([]);
  const [searchParams, setSearchParams] = useState({ name: '',description: '' ,price: '', quantityStock: '' });

  useEffect(() => {
    fetchProducts();
  }, []);
  
  const fetchProducts = async (filters = {}) => {
    try {
      console.log('Sending API request with filters:', filters);
      const data = await getProducts(filters);
      setProducts(data);
    } catch (error) {
      console.error('Error fetching products:', error);
    }
  };
  const handleSearch = () => {
    fetchProducts(searchParams);
  };
  const handleClear = () => {
    setSearchParams({ name: '',description:'', price: '', quantityStock: '' });
    fetchProducts();
  }

  const columns: TableProps<DataType>['columns'] = [
    {
      title: 'ID',
      dataIndex: 'id',
      key: 'id',
    },
    {
      title: 'Name',
      dataIndex: 'name',
      key: 'name',
      render: (text) => <a>{text}</a>,
    },
    {
      title: 'Description',
      dataIndex: 'description',
      key: 'description',
      render: (text)=><a >{text}</a>
    },
    {
      title: 'Price',
      dataIndex: 'price',
      key: 'price',
    },
    {
      title: 'Quantity Stock',
      dataIndex: 'quantityStock',
      key: 'quantityStock',
    },
    {
      title: 'Action',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <a><EditTwoTone /></a>
          <a><DeleteTwoTone /></a>
        </Space>
      ),
    },
  ];
  return  <div>
    <div style={{
      //marginLeft:"90rem",
      marginTop:"10px",
      marginBottom:"10px",
      //maxWidth:"550px",
      display:"flex",
      flexDirection:"row-reverse",
    }}> {/* <SearchBar/> */} 
   
    </div>
    <Form
      form={form}
      layout="vertical"
      style={{
      marginTop: "10px",
      marginBottom: "10px",
      maxWidth: "550px",
      }}
    >
      <div style={{ display: 'flex', justifyContent: 'space-between' }}>
      <Form.Item
        style={{ flex: 1, marginRight: '10px' }}
        tooltip={{ title: 'Tooltip with customize icon', icon: <InfoCircleOutlined /> }}
      >
        <Input
        placeholder="Search by Name"
        value={searchParams.name}
        onChange={(e) => setSearchParams({ ...searchParams, name: e.target.value })}
        />
      </Form.Item>
      <Form.Item
        style={{ flex: 1, marginLeft: '10px' }}
        tooltip={{ title: 'Tooltip with customize icon', icon: <InfoCircleOutlined /> }}
      >
        <Input
        placeholder="Search by Description"
        value={searchParams.description}
        onChange={(e) => setSearchParams({ ...searchParams, description: e.target.value })}
        />
      </Form.Item>
      </div>
      <div style={{ display: 'flex', justifyContent: 'space-between' }}>
      <Form.Item
        style={{ flex: 1, marginRight: '10px' }}
        tooltip={{ title: 'Tooltip with customize icon', icon: <InfoCircleOutlined /> }}
      >
        <Input
        placeholder="Search by Price"
        type="number"
        value={searchParams.price}
        onChange={(e) => setSearchParams({ ...searchParams, price: e.target.value })}
        />
      </Form.Item>
      <Form.Item
        style={{ flex: 1, marginLeft: '10px' }}
        tooltip={{ title: 'Tooltip with customize icon', icon: <InfoCircleOutlined /> }}
      >
        <Input
        placeholder="Search by Quantity"
        type="number"
        value={searchParams.quantityStock}
        onChange={(e) => setSearchParams({ ...searchParams, quantityStock: e.target.value })}
        />
      </Form.Item>
      </div>
      <div style={{ display: 'flex', justifyContent: 'space-between' }}>
      <Form.Item >
      <Button type="primary" onClick={handleClear} style={{marginRight: '10px' }}>
          Clear
        </Button>
      <Button type="primary" onClick={handleSearch}>Search</Button>
      </Form.Item>
      </div>
    </Form>
    <Table columns={columns} dataSource={products } rowKey="id"/>
    
  </div>
  
 
}//<Table<DataType> columns={columns} dataSource={data} />;

export default Test;