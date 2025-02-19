import { AudioOutlined } from '@ant-design/icons';
import { Space,Input, GetProps} from 'antd';
import React from 'react';

type SearchProps = GetProps<typeof Input.Search>;

const { Search } = Input;

const suffix = (
  <AudioOutlined
    style={{
      fontSize: 16,
      color: '#1677ff',
    }}
  />
);

const onSearch: SearchProps['onSearch'] = (value, _e, info) => console.log(info?.source, value);

const SearchBar:React.FC = () => (

    <Space direction="vertical" style={{ width: '100%' }}>
        <Search
        placeholder="input search text"
        allowClear
        enterButton="Search"
        size="large"
        suffix={suffix}
        onSearch={onSearch}
        />
    </Space>
    );
export default SearchBar;