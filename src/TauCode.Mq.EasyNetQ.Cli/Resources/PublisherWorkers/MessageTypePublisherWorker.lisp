(defblock :name get-publisher-message-type :is-top t
	(worker
		:worker-name get-publisher-message-type
		:verb "message-type"
		:description "Gets message type description by name or its part."
		:usage-samples (
			"pub type Foo.MyMessage"
			"pub type MyMes"
			"pub type 'MyMes'"))


	(some-text
		:classes term string
		:action argument
		:alias type-name
		:description "Type name, or part of type name."
		:doc-subst "type name")

	(end)
)
