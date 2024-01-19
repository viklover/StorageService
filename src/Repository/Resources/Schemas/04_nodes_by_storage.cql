CREATE TABLE IF NOT EXISTS storage.nodes_by_storage (
    storage_id SMALLINT,
    key   BIGINT,
    value TEXT,
    tree_info FROZEN<storage.node_position>,
    PRIMARY KEY ((storage_id), key)
) WITH CLUSTERING ORDER BY (key ASC);